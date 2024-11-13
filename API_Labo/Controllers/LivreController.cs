using API_Labo.Mapper;
using API_Labo.Models.Forms;
using BLL_Labo.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API_Labo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LivreController(ILivreService _livreService) : ControllerBase {

        [HttpGet]
        public IActionResult Get() {
            return Ok(_livreService.Get().Select(l => l.ToLivre()));
        }

        [HttpGet("{livreId}")]
        public IActionResult Get(int livreId) {
            try {
                return Ok(_livreService.Get(livreId).ToLivreDetails());
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("ParAuteur/{auteurId}")]
        public IActionResult ParAuteur(int auteurId) {
            try {
                return Ok(_livreService.ParAuteur(auteurId).Select(l => l.ToLivreDetails()));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("ParGenre/{genre}")]
        public IActionResult ParGenre(string genre) {
            try {
                return Ok(_livreService.ParGenre(genre).Select(l => l.ToLivreDetails()));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpPost]
        public IActionResult Post([FromBody] LivreForm l) {
            if (!ModelState.IsValid) return BadRequest();

            try {
                int result = _livreService.Create(l.ToEntity(), l.AuteursId.ToArray());

                return Ok();
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LivreForm l) {
            if (!ModelState.IsValid) return BadRequest();

            try {
                return Ok(_livreService.Update(id, l.ToEntity()));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("AdminRequired")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                return Ok(_livreService.Delete(id));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }
    }
}
