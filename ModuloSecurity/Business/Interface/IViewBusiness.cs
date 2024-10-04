using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IViewBusiness
    {
        public Task Delete(int id);
        public Task LogicalDelete(int id);
        public Task<ViewDto> GetById(int id);
        public Task<IEnumerable<ViewDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<View>Save(ViewDto entity);
        public Task Update(ViewDto entity);
    }
}