using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class ViewBusiness : IViewBusiness
    {
        protected readonly IViewData data;

        public ViewBusiness(IViewData data)
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
        public async Task<IEnumerable<ViewDto>>GetAll()
        {
            IEnumerable<View> views = (IEnumerable<View>)await this.data.GetAll();
            var viewDtos = views.Select(view => new ViewDto
            {
                Id = view.Id,
                Name = view.Name,
                Description = view.Description,
                State = view.State,
                ModuloId = view.ModuloId,
            });
            return viewDtos;
        }
        public async Task<IEnumerable<DataSelectDto>>GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<ViewDto>GetById(int id)
        {
            View view = await this.data.GetById(id);
            ViewDto viewDto = new ViewDto();

            viewDto.Id = view.Id;
            viewDto.Name = view.Name;
            viewDto.Description = view.Description;
            viewDto.State = view.State;
            viewDto.ModuloId = view.ModuloId;

            return viewDto;
        }
        public View mapearDatos(View view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.Name = entity.Name;
            view.Description = entity.Description;
            view.State = entity.State;
            view.ModuloId = entity.ModuloId;
            return view;
        }
        public async Task<View>Save(ViewDto entity)
        {
            View view = new View
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            view = this.mapearDatos(view, entity);
            return await this.data.Save(view);
        }
        public async Task Update(ViewDto entity)
        {
            View view = await this.data.GetById(entity.Id);
            view.UpdateAt = DateTime.Now.AddHours(-5);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            view = this.mapearDatos(view, entity);
            await this.data.Update(view);
        }
    }
}
