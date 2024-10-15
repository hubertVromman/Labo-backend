using API_Labo.Mapper;
using API_Labo.Models.DTO;
using BLL_Labo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Labo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PretController : ControllerBase {
        private readonly IPretService _pretService;

        public PretController(IPretService pretService) {
            _pretService = pretService;
        }

        [HttpGet]
        public IActionResult Get() {
            try {
                return Ok(_pretService.Get());
            } catch (Exception ex) {
                return NotFound();
            }
        }

        [HttpGet("id")]
        public IActionResult Get(int id) {
            try {
                return Ok(_pretService.Get(id));
            } catch (Exception ex) {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Commande commande) {
            try {
                int result = _pretService.Create(commande.ToBLL());
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
