using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IRoleViewController
    {
        public Task<ActionResult<IEnumerable<RoleViewDto>>> GetAll();
        public Task<ActionResult<RoleViewDto>> Save([FromBody] RoleViewDto roleViewDto);
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
        public Task<IActionResult> Update([FromBody] RoleViewDto roleViewDto);
    }
}