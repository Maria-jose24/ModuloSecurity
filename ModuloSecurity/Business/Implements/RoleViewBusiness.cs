using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class RoleViewBusiness : IRoleViewBusiness
    {
        protected readonly IRoleViewData data;
        public RoleViewBusiness(IRoleViewData data)
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
        public async Task<IEnumerable<RoleViewDto>> GetAll()
        {
            IEnumerable<RoleView> roleViews = await this.data.GetAll();
            var roleViewDtos = roleViews.Select(roleView => new RoleViewDto
{
                Id = roleView.Id,
                State = roleView.State,
                RoleId = roleView.RoleId,
                ViewId = roleView.ViewId,
            });

            return roleViewDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<RoleViewDto> GetById(int id)
        {
            RoleView roleView = await this.data.GetById(id);
            RoleViewDto roleViewDto = new RoleViewDto();
            roleViewDto.Id = roleView.Id;
            roleViewDto.State = roleView.State;
            roleViewDto.RoleId = roleView.RoleId;
            roleViewDto.ViewId = roleView.ViewId;
            return roleViewDto;
        }
        public RoleView mapearDatos(RoleView roleView, RoleViewDto entity)
        {
            roleView.Id = entity.Id;
            roleView.State = entity.State;
            roleView.RoleId = entity.RoleId;
            roleView.ViewId = entity.ViewId;
            return roleView;
        }
        public async Task<RoleView> Save(RoleViewDto entity)
        {
            RoleView roleView = new RoleView
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            roleView = this.mapearDatos(roleView, entity);
            return await this.data.Save(roleView);
        }
        public async Task Update(RoleViewDto entity)
        {
            RoleView roleView = await this.data.GetById(entity.Id);
            if (roleView == null)
            {
                throw new Exception("Registro no encontrado");
            }
            roleView.UpdateAt = DateTime.Now.AddHours(-5);
            roleView = this.mapearDatos(roleView, entity);
            await this.data.Update(roleView);
        }
    }
}