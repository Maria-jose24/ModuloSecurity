using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IViewController
    {
        public Task<ActionResult<IEnumerable<ViewDto>>> GetAll();
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
        public Task<ActionResult<ViewDto>> Save([FromBody] ViewDto viewDto);
        public Task<IActionResult> Update([FromBody] ViewDto viewDto);
    }
}