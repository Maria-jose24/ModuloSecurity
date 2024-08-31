﻿using Entity.DTO;
using Entity.Model.Security;

namespace Business.Interfaces
{
    public interface IRoleBusiness
    {
        Task<IEnumerable<RoleDto>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();

        Task<RoleDto> GetById(int id);

        Task<Role> Save(RoleDto entity);

        Task Update(RoleDto entity);

        Task Delete(int id);
    }
}
