using Entity.DTO;
using Entity.Model.Security;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interfaces
{
    public interface IStateController
    {
        public Task<IActionResult> Delete(int id);

        public Task<ActionResult<StateDto>> GetById(int id);

        public Task<ActionResult<State>> Save([FromBody] StateDto stateDto);

        public Task<IActionResult> Update([FromBody] StateDto stateDto);

        public Task<ActionResult<IEnumerable<StateDto>>> GetAll();
    }
}