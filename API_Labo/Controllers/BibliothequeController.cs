using API_Labo.Mapper;
using API_Labo.Models.Forms;
using BLL_Labo.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Labo.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BibliothequeController(IBibliothequeService _bibliothequeService) : ControllerBase {

        [HttpGet]
        public IActionResult Get() {
            return Ok(_bibliothequeService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                return Ok(_bibliothequeService.Get(id));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("AvecStock/{id}")]
        public IActionResult GetAvecStock(int id) {
            try {
                return Ok(_bibliothequeService.AvecStock(id));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpPost]
        public IActionResult Post([FromBody] BibliothequeForm b) {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_bibliothequeService.Create(b.ToEntity()));
        }

        [Authorize("EmployeeRequired")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BibliothequeForm b) {
            if (!ModelState.IsValid) return BadRequest();
            try {
                return Ok(_bibliothequeService.Update(id, b.ToEntity()));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("AdminRequired")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                return Ok(_bibliothequeService.Delete(id));
            } catch (ArgumentOutOfRangeException ex) {
                return NotFound(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpPut("AjouterStock")]
        public IActionResult AjouterStock([FromBody] StockForm s) {
            if (!ModelState.IsValid) return BadRequest();

            try {
                return Ok(_bibliothequeService.AjouterStock(s.ToBLL()));
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            } catch (DbUpdateException ex) {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpPut("SetStock")]
        public IActionResult SetStock([FromBody] StockFormRequired s) {
            if (!ModelState.IsValid) return BadRequest();

            try {
                return Ok(_bibliothequeService.SetStock(s.ToBLL()));
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            } catch (DbUpdateException ex) {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("EmployeeRequired")]
        [HttpPut("RetirerStock")]
        public IActionResult RetirerStock([FromBody] StockFormRequired s) {
            if (!ModelState.IsValid) return BadRequest();

            try {
                return Ok(_bibliothequeService.RetirerStock(s.ToBLL()));
            } catch (ArgumentException ex) {
                return BadRequest(ex.Message);
            } catch (DbUpdateException ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
