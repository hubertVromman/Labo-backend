using API_Labo.Mapper;
using API_Labo.Models.Forms;
using API_Labo.Models.DTO;
using API_Labo.Tools;
using BCrypt.Net;
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

namespace TFCloud_Blazor_ApiSample.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController(IUtilisateurService _utilisateurService, JwtGenerator jwt) : ControllerBase {

        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterForm form) {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string hashpwd = BCrypt.Net.BCrypt.HashPassword(form.MotDePasse);

            try {
                _utilisateurService.Register(
                    email: form.Email.ToLower(),
                    motDePasse: hashpwd,
                    nom: form.Nom,
                    prenom: form.Prenom
                );
                return Ok("Inscription réussie");
            } catch (DbUpdateException ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginForm loginForm) {
            if (!ModelState.IsValid) return BadRequest();

            Entities.Utilisateur? u = _utilisateurService.GetUserByEmail(loginForm.Email.ToLower());

            if (u is not null && BCrypt.Net.BCrypt.Verify(loginForm.MotDePasse, u.MotDePasse)) {
                string token = jwt.GenerateToken(u);
                return Ok(token);
            }
            return BadRequest("Mot de passe invalide");
        }

        [Authorize("AdminRequired")]
        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_utilisateurService.GetAll().Select(u => u.ToUtilisateur()));
        }

        [Authorize("UserRequired")]
        [HttpGet("Profile")]
        public IActionResult GetUserInfo() {
            string tokenFromRequest = HttpContext.Request.Headers["Authorization"];
            string token = tokenFromRequest.Substring(7, tokenFromRequest.Length - 7);
            JwtSecurityToken jwt = new JwtSecurityToken(token);
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
