using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class CityData : ICityData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public CityData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null) throw new Exception("Registro NO encontrado");
            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.Citys.Remove(entity);
            await context.SaveChangesAsync();
        }

        // Método para eliminar un registro de City
        public async Task LogicalDelete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }

            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.Citys.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-', Postalcode,) AS TextoMostrar
                FROM
                citys
                WHERE DeletedAt IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<CityDto>> GetAll()
        {
            var sql = @"SELECT c.*, s.Name As StateName FROM citys c
            INNER JOIN states s ON c.StateId = s.Id Order BY Id ASC";
            return await context.QueryAsync<CityDto>(sql);
            
        }

        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM citys WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }
        public async Task<City> Save(City entity)
        {
            context.Citys.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(City entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}