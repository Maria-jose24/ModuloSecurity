using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface ICityController
    {
        Task<ActionResult<IEnumerable<CityDto>>> GetAll();
        Task<ActionResult<City>> Save([FromBody] CityDto cityDto);
        Task<IActionResult> Update([FromBody] CityDto cityDto);
        Task<IActionResult> Delete(int id);
    }
}