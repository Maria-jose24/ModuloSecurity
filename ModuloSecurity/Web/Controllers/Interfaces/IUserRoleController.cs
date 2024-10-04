using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IUserRoleController
    {
        public Task<IActionResult> Delete(int  id);
        public Task<IActionResult> LogicalDelete(int id);
        public Task<ActionResult<UserRoleDto>> Save([FromBody]UserRoleDto userRoleDto);
        public Task<IActionResult> Update([FromBody]UserRoleDto userRoleDto);
        public Task<ActionResult<IEnumerable<UserRoleDto>>> GetAll();
    }
}