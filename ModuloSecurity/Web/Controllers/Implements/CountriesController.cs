using Business.Interface;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Implements
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesBusiness _countriesBusiness;

        public CountriesController(ICountriesBusiness countriesBusiness)
        {

            _countriesBusiness = countriesBusiness;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountriesDto>>> GetAll()
        {
            var result = await _countriesBusiness.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CountriesDto>> GetById(int id)
        {
            var result = await _countriesBusiness.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<Countries>> Save([FromBody] CountriesDto entity)
        {
            if (entity == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await _countriesBusiness.Save(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CountriesDto entity)
        {
            if (entity != null || entity.Id == 0)
            {
                return BadRequest();
            }
            await _countriesBusiness.Update(entity);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _countriesBusiness.Delete(id);
            return NoContent();
        }
    }
}

