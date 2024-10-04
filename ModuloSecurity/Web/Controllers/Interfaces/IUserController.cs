using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IUserController
    {
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
        public Task<ActionResult<UserDto>> Save([FromBody] UserDto userDto);
        public Task<IActionResult> Update([FromBody] UserDto userDto);
        public Task<ActionResult<IEnumerable<UserDto>>> GetAll();
    }
}