using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICountriesController
    {
        public Task<ActionResult<IEnumerable<CountriesDto>>> GetAll();
        public Task<ActionResult<CountriesDto>> GetById(int id);
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
        public Task<ActionResult<CountriesDto>> Save([FromBody] CountriesDto countriesDto);
        public Task<IActionResult> Update([FromBody] CountriesDto countriesDto);
    }
}