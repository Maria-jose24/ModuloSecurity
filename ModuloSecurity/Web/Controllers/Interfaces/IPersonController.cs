using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IPersonController
    {
        Task<ActionResult<IEnumerable<PersonDto>>> GetAll();
        Task<ActionResult<Person>> Save([FromBody] PersonDto person);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Update([FromBody] PersonDto personDto);
    }
}