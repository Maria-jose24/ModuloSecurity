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
        public async Task Delete(int id, bool isSoftDelete = true)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }

            if (isSoftDelete)
            {
                // Si ya está eliminado, restaurarlo
                if (entity.DeleteAt != null)
                {
                    entity.DeleteAt = null; // Restaurar si ya había sido eliminado lógicamente
                }
                else
                {
                    entity.DeleteAt = DateTime.Now; // Eliminar lógicamente
                }

                context.UserRoles.Update(entity);
            }
            else
            {
                // Borrado físico
                context.UserRoles.Remove(entity);
            }

            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-', Description) AS TextoMostrar
                FROM
                UserRoles
                WHERE DeletedAt IS NULL
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<UserRole> GetById(int id)
        {
            var sql = @"SELECT * FROM UserRoles WHERE Id = @Id AND DeleteAt IS NULL ORDER BY Id ASC";
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
        public async Task<UserRole> GetByName(int id)
        {
            return await this.context.UserRoles.AsNoTracking().Where(item => item.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<UserRole>> GetAll()
        {
            var sql = @"SELECT * FROM UserRoles ORDER BY Id ASC";
            return await this.context.QueryAsync<UserRole>(sql);
        }

    }
}