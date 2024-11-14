using API_Labo.Mapper;
using API_Labo.Models.Forms;
using API_Labo.Models.DTO;
using BLL_Labo.Interfaces;
using BLL_Labo.Services;
using Entities = EntityFramework.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using BLL_Labo.Entities;
using Microsoft.Data.SqlClient;

namespace TFCloud_Blazor_ApiSample.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController(IUtilisateurService _utilisateurService, AuthService _authService) : ControllerBase {

        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterForm form) {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //string hashpwd = BCrypt.Net.BCrypt.HashPassword(form.MotDePasse);

            try {
                _utilisateurService.Register(
                    email: form.Email.ToLower(),
                    motDePasse: form.MotDePasse,
                    nom: form.Nom,
                    prenom: form.Prenom
                );
                return Ok();
            } catch (SqlException ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginForm loginForm) {
            if (!ModelState.IsValid) return BadRequest();

            Entities.Utilisateur u;
            try {
                u = _utilisateurService.Login(loginForm.Email.ToLower(), loginForm.MotDePasse);
                Token t = _authService.GenerateTokensFromUser(u);
                return Ok(t);
            } catch (ArgumentException ex) {
                return BadRequest("Mot de passe invalide");
            } catch (DbUpdateException ex) {
                return BadRequest("Erreur de sauvegarde du token");
            }

            //&& BCrypt.Net.BCrypt.Verify(loginForm.MotDePasse, u.MotDePasse)) {
        }

        [HttpPost("RefreshToken")]
        public IActionResult RefreshToken([FromBody] TokenForm token) {
            JwtSecurityToken jwt = new JwtSecurityToken(token.AccessToken);
            Console.WriteLine(jwt.ValidTo);
            if (!ModelState.IsValid) return BadRequest();

            try {
                Token t = _authService.RefreshToken(token.ToBLL());
                return Ok(t);
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [Authorize("AdminRequired")]
        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_utilisateurService.GetAll().Select(u => u.ToUtilisateur()));
        }

        [Authorize("UserRequired")]
        [HttpGet("Profile")]
        public IActionResult GetUserInfo() {
            string? tokenFromRequest = HttpContext.Request.Headers["Authorization"];
            if (tokenFromRequest is null)
                return Unauthorized();
            string token = tokenFromRequest.Substring(7, tokenFromRequest.Length - 7);
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            Console.WriteLine(jwt.ValidTo);
            string email = jwt.Claims.First(x => x.Type == ClaimTypes.Email).Value;
            try {
                return Ok(_utilisateurService.GetUserByEmail(email).ToUtilisateur());
            } catch (ArgumentException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("AdminRequired")]
        [HttpPut("Role/{id}")]
        public IActionResult ChangeRole(int id, [FromBody]RoleForm nouveauRole) {
            if (!ModelState.IsValid) return BadRequest();

            try {
                return Ok(_utilisateurService.ChangeRole(id, nouveauRole.Role));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
