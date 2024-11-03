using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class StateBusiness : IStateBusiness
    {
        protected readonly IStateData data;

        public StateBusiness(IStateData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task LogicalDelete(int id)
        {
            await this.data.LogicalDelete(id);
        }
        
        public async Task<IEnumerable<StateDto>> GetAll()
        {
            IEnumerable<StateDto> states = await this.data.GetAll();
            /*var stateDtos = states.Select(state => new StateDto
            {
                Id = state.Id,
                Name = state.Name,
                CountriesId = state.CountriesId,
                CountriesName = state.Countries?.Name,
            });*/
            return states;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<StateDto> GetById(int id)
        {
            State state = await this.data.GetById(id);
            StateDto stateDto = new StateDto();

            stateDto.Id = state.Id;
            stateDto.Name = state.Name;
            stateDto.CountriesId = state.CountriesId;

            return stateDto;
        }
        public State mapearDatos(State state, StateDto entity)
        {
            state.Id = entity.Id;
            state.Name = entity.Name;
            state.CountriesId = entity.CountriesId;
            return state;
        }

        public async Task<State> Save(StateDto entity)
        {
            State state = new State
            {
                CreateAt = DateTime.Now.AddHours(-5),
            };
            state = this.mapearDatos(state, entity);
            return await this.data.Save(state);
        }
        public async Task Update(StateDto entity)
        {
            State state = await this.data.GetById(entity.Id);
            state.UpdateAt = DateTime.Now.AddHours(-5);
            if (state == null)
            {
                throw new Exception("Registro no encontrado");
            }
            state = this.mapearDatos(state, entity);
            await this.data.Update(state);
        }
    }
}