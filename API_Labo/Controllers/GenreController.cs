using API_Labo.Mapper;
using API_Labo.Models.Forms;
using BLL_Labo.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Labo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController(IGenreService _genreService) : ControllerBase {

        [HttpGet]
        public IActionResult Get() {
            return Ok(_genreService.Get().Select(g => g.ToGenre()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_genreService.Get(id).ToGenre());
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpPost]
        public IActionResult Post([FromBody] GenreForm g) {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_genreService.Create(g.ToEntity()));
        }

        [Authorize("EmployeeRequired")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenreForm g) {
            if (!ModelState.IsValid) return BadRequest();

            try {
                return Ok(_genreService.Update(id, g.ToEntity()));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("AdminRequired")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                return Ok(_genreService.Delete(id));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }
    }
}
