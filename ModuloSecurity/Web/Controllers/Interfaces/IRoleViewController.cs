using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleViewController
    {
        Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll();
        Task<ActionResult<RoleView>> Save([FromBody] RoleViewDto roleViewDto);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Update([FromBody] RoleViewDto roleViewDto);
    }
}