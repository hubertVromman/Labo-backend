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
using API_Labo.Models.DTO;


namespace API_Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenteController : ControllerBase
    {
        private readonly IVenteService _venteService;

        public VenteController(IVenteService venteService)
        {
            _venteService = venteService;
        }

        [HttpGet]
        public IActionResult Get() {
            try {
                return Ok(_venteService.Get());
            } catch (Exception ex) {
                return NotFound();
            }
        }

        [HttpGet("id")]
        public IActionResult Get(int id) {
            try {
                return Ok(_venteService.Get(id));
            } catch (Exception ex) {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult Create([FromBody] Commande commande) {
            try {
                int result = _venteService.Create(commande.ToBLL());
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
