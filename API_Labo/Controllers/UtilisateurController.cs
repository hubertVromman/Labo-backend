using API_Labo.Models.DTO;
using API_Labo.Tools;
using BCrypt.Net;
using BLL_Labo.Interfaces;
using BLL_Labo.Services;
using EntityFramework.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TFCloud_Blazor_ApiSample.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UtilisateurController : ControllerBase {
        private readonly IUtilisateurService _utilisateurService;
        private readonly JwtGenerator jwt;

        public UtilisateurController(IUtilisateurService utilisateurService, JwtGenerator _jwt) {
            this._utilisateurService = utilisateurService;
            this.jwt = _jwt;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] RegisterForm form) {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            string hashpwd = BCrypt.Net.BCrypt.HashPassword(form.MotDePasse);

            Console.WriteLine(hashpwd);

            if (_utilisateurService.Register(
                email : form.Email,
                motDePasse : hashpwd,
                nom : form.Nom,
                prenom : form.Prenom
            )) {
                return Ok("Inscription réussie");
            }
            return BadRequest("t'as du merder");
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginForm loginForm) {
            if (!ModelState.IsValid) return BadRequest();

            Utilisateur? u = _utilisateurService.GetUserByEmail(loginForm.Email);

            if (u is not null && BCrypt.Net.BCrypt.Verify(loginForm.MotDePasse, u.MotDePasse)) {
                string token = jwt.GenerateToken(u);
                return Ok(token);
            }
            return BadRequest("Mot de passe invalide");
        }

        [Authorize("adminRequired")]
        [HttpGet]
        public IActionResult GetAll() {
            return Ok(_utilisateurService.GetAll());
        }

        [Authorize("userRequired")]
        [HttpGet("profile")]
        public IActionResult GetUserInfo() {
            string tokenFromRequest = HttpContext.Request.Headers["Authorization"];
            string token = tokenFromRequest.Substring(7, tokenFromRequest.Length - 7);
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            string email = jwt.Claims.First(x => x.Type == ClaimTypes.Email).Value;
            return Ok(_utilisateurService.GetUserByEmail(email));
        }
    }
}
