using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using API_Labo.Mapper;
using BLL_Labo.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using BLL_Labo.Services;
using API_Labo.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace API_Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenteController(IVenteService _venteService) : ControllerBase {

        [Authorize("EmployeeRequired")]
        [HttpGet]
        public IActionResult Get() {
            try {
                return Ok(_venteService.Get().Select(v => v.ToVente()));
            } catch (Exception ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_venteService.Get(id).ToVente());
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
                int result = _venteService.Create(c);
                return Ok(result);
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
                return Ok(_venteService.ParUtilisateur(utilisateurId).Select(v => v.ToVente()));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
