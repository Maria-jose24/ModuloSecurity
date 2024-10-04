using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleController
    {
        public Task<ActionResult<IEnumerable<RoleDto>>> GetAll();
        public Task<ActionResult<RoleDto>> GetById(int id);
        public Task<ActionResult<RoleDto>> Save([FromBody] RoleDto roleDto);
        public Task<IActionResult>Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
        public Task<IActionResult> Update([FromBody] RoleDto roleDto);
    }
}