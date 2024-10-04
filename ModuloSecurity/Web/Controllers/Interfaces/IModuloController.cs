using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IModuloController
    {
        public Task<ActionResult<IEnumerable<ModuloDto>>> GetAll();
        public Task<ActionResult<ModuloDto>> GetById(int id);
        public Task<ActionResult<ModuloDto>> Save([FromBody] ModuloDto moduloDto);
        public Task<IActionResult>Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
        public Task<IActionResult> Update([FromBody]ModuloDto moduloDto);
    }
}