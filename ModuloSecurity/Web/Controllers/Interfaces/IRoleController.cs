using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleController
    {
        Task<ActionResult<IEnumerable<RoleDto>>> GetAll();
        Task<ActionResult<Role>> Save([FromBody] RoleDto roleDto);
        Task<IActionResult>Delete(int id);
        Task<IActionResult> Update([FromBody] RoleDto roleDto);
    }
}