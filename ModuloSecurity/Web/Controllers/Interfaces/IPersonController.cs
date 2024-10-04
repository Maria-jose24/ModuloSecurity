using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IPersonController
    {
        public Task<ActionResult<IEnumerable<PersonDto>>> GetAll();
        public Task<ActionResult<PersonDto>> GetById(int id);
        public Task<ActionResult<PersonDto>> Save([FromBody] PersonDto person);
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> LogicalDelete(int id);
        public Task<IActionResult> Update([FromBody] PersonDto personDto);
    }
}