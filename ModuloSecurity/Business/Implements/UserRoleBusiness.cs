﻿using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class UserRoleBusiness : IUserRoleBusiness
    {
        protected readonly IUserRoleData data;

        public UserRoleBusiness(IUserRoleData data)
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
        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            IEnumerable<UserRoleDto> userRoles = await this.data.GetAll();
            /*var userRoleDtos = userRoles.Select(userRole => new UserRoleDto
            {
                Id = userRole.Id,
                State = userRole.State,
                UserId = userRole.UserId,
                UserName = userRole.User?.Username
            });*/
            return userRoles;
        }
        public async Task<IEnumerable<DataSelectDto>>GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<UserRoleDto>GetById(int id)
        {
            UserRole userRole = await this.data.GetById(id);
            UserRoleDto userRoleDto = new UserRoleDto();

            userRoleDto.Id = userRole.Id;
            userRoleDto.RoleId = userRole.RoleId;
            userRoleDto.State = userRole.State;
            userRoleDto.UserId = userRole.UserId;
            return userRoleDto;
        }
        public UserRole mapearDatos(UserRole userRole, UserRoleDto entity)
        {
            userRole.Id = entity.Id;
            userRole.RoleId = entity.RoleId;
            userRole.UserId = entity.UserId;
            userRole.State = entity.State;
            return userRole;
        }
        public async Task<UserRole>Save(UserRoleDto entity)
        {
            UserRole userRole = new UserRole
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            userRole = this.mapearDatos(userRole, entity);
            return await this.data.Save(userRole);
        }
        public async Task Update(UserRoleDto entity)
        {
            UserRole userRole = await this.data.GetById(entity.Id);
            userRole.UpdateAt = DateTime.Now.AddHours(-5);
            if(userRole == null)
            {
                throw new Exception("Registro no encontrado");
            }
            userRole = this.mapearDatos(userRole,entity);
            await this.data.Update(userRole);
        }
    }
}