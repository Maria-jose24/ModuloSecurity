using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Implements
{
    public class RoleData : IRoleData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;
        public RoleData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Roles.Remove(entity);
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
            context.Roles.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-', Description, State) AS TextoMostrar
                FROM
                Roles
                WHERE DeletedAt IS NULL
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<Role> GetById(int id)
        {
            var sql = @"SELECT * FROM Roles WHERE Id = @Id AND DeleteAt IS NULL ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Role>(sql, new { Id = id });
        }
        public async Task<Role> Save(Role entity)
        {
            context.Roles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Role entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<Role> GetByName(string name)
        {
            return await this.context.Roles.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<RoleDto>> GetAll()
        {
            var sql = @"SELECT * FROM Roles ORDER BY Id ASC";
            return await this.context.QueryAsync<RoleDto>(sql);
        }

    }
}
