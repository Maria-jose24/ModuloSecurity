using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Implements
{
    public class UserRoleData : IUserRoleData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public UserRoleData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.UserRoles.Remove(entity);
            await context.SaveChangesAsync();
        }
        // Método para eliminar un registro de ViewRol
        public async Task LogicalDelete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }

            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.UserRoles.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-', Description) AS TextoMostrar
                FROM
                userroles
                WHERE DeletedAt IS NULL
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<CityDto>> GetAll()
            {
                var sql = @"SELECT ur.*, u.Name As UserName, r.Name AS RoleName,
                FROM userRoles ur
                INNER JOIN user u ON ur.UserId = u.Id
                INNER JOIN roles r ON ur.RoleId = r.Id
                Order BY Id ASC";
                var citys = await this.context.QueryAsync<CityDto>(sql);
                return citys;
            }
        
        public async Task<UserRole> GetById(int id)
        {
            var sql = @"SELECT * FROM userroles WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<UserRole>(sql, new { Id = id });
        }
        public async Task<UserRole> Save(UserRole entity)
        {
            context.UserRoles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(UserRole entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}