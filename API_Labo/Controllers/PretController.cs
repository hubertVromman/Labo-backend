using API_Labo.Mapper;
using API_Labo.Models.Forms;
using BLL_Labo.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API_Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PretController(IPretService _pretService) : ControllerBase {

        [Authorize("EmployeeRequired")]
        [HttpGet]
        public IActionResult Get() {
            try {
                return Ok(_pretService.Get().Select(p => p.ToPret()).ToList());
            } catch (Exception ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_pretService.Get(id).ToPret());
            } catch (Exception ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("UserRequired")]
        [HttpPost]
        public IActionResult Create([FromBody] Commande commande) {

            string tokenFromRequest = HttpContext.Request.Headers["Authorization"];
            string token = tokenFromRequest.Substring(7, tokenFromRequest.Length - 7);
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            int utilisateurId = int.Parse(jwt.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            try {
                BLL_Labo.Entities.Commande c = commande.ToBLL();
                c.UtilisateurId = utilisateurId;
                int result = _pretService.Create(c);
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("UserRequired")]
        [HttpPost("Rendre/{id}")]
        public IActionResult Rendre(int id) {

            string tokenFromRequest = HttpContext.Request.Headers["Authorization"];
            string token = tokenFromRequest.Substring(7, tokenFromRequest.Length - 7);
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            int utilisateurId = int.Parse(jwt.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            try {
                int result = _pretService.Rendre(id, utilisateurId);
                return Ok(result);
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            } catch (UnauthorizedAccessException ex) {
                return Unauthorized(ex.Message);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("UserRequired")]
        [HttpGet("ParUtilisateur")]
        public IActionResult ParUtilisateur() {

            string tokenFromRequest = HttpContext.Request.Headers["Authorization"];
            string token = tokenFromRequest.Substring(7, tokenFromRequest.Length - 7);
            JwtSecurityToken jwt = new JwtSecurityToken(token);
            int utilisateurId = int.Parse(jwt.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);

            try {
                return Ok(_pretService.ParUtilisateur(utilisateurId).Select(p => p.ToPret()));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
