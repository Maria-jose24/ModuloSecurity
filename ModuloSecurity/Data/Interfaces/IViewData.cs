using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IViewData
    {
        public Task Delete(int id);

        public Task<View> GetById(int id);

        public Task<View> Save(View entity);

        public Task Update(View entity);

        public Task<IEnumerable<View>> GetAll();

        public Task<View>GetByName(string name);

        Task<UserRole> Save(UserRole userRole);
    }
}