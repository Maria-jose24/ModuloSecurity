﻿using Entity.DTO;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IRoleViewData
    {
        public Task Delete(int id);
        public Task<RoleView> GetById(int id);
        public Task<RoleView> Save(RoleView entity);
        public Task Update(RoleView entity);
        public Task<IEnumerable<RoleView>> GetAll();
        public Task<RoleView>GetByName(int id);
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}