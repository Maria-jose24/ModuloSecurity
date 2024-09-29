using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IModuloController
    {
        Task<ActionResult<IEnumerable<ModuloDto>>> GetAll();
        Task<ActionResult<Modulo>> Save([FromBody] ModuloDto moduloDto);
        Task<IActionResult>Delete(int id);
        Task<IActionResult> Update([FromBody]ModuloDto moduloDto);
    }
}