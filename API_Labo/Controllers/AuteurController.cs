using API_Labo.Models.Forms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Labo.Mapper;
using BLL_Labo.Interfaces;

namespace API_Labo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuteurController(IAuteurService _auteurService) : ControllerBase {

        [HttpGet]
        public IActionResult Get() {
            return Ok(_auteurService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_auteurService.Get(id));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpPost]
        public IActionResult Post([FromBody] AuteurForm a) {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_auteurService.Create(a.ToEntity()));
        }

        [Authorize("EmployeeRequired")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AuteurForm a) {
            if (!ModelState.IsValid) return BadRequest();

            try {
                return Ok(_auteurService.Update(id, a.ToEntity()));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("AdminRequired")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                return Ok(_auteurService.Delete(id));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }
    }
}
