using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface IViewBusiness
    {
        Task Delete(int id);
        Task LogicalDelete(int id);
        Task<ViewDto> GetById(int id);
        Task<IEnumerable<ViewDto>> GetAll();
        Task<View>Save(ViewDto entity);
        Task Update(ViewDto entity);
    }
}
