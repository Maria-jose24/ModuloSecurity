using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class ModuloData : IModuloData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ModuloData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Modulos.Remove(entity);
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
            context.Modulos.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>>GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-', Description) AS TextoMostrar
                FROM
                modulos
                WHERE DeletedAt IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<IEnumerable<ModuloDto>> GetAll()
        {
            var sql = @"SELECT * FROM modulos WHERE DeleteAt IS NULL AND State = 1 ORDER BY Id ASC";
            return await this.context.QueryAsync<ModuloDto>(sql);
        }
        public async Task<Modulo>GetById(int id)
        {
            var sql = @"SELECT * FROM modulos WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Modulo>(sql, new { Id = id });
        }
        public async Task<Modulo>Save(Modulo entity)
        {
            context.Modulos.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Modulo entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
