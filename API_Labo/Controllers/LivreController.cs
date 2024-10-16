using API_Labo.Mapper;
using API_Labo.Models.Forms;
using BLL_Labo.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Labo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LivreController(ILivreService _livreService) : ControllerBase {

        [HttpGet]
        public IActionResult Get() {
            return Ok(_livreService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_livreService.Get(id));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpPost]
        public IActionResult Post([FromBody] LivreForm l) {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_livreService.Create(l.ToEntity()));
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
