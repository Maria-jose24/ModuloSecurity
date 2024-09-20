using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class StateData : IStateData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public StateData(ApplicationDBContext context, IConfiguration configuration)
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

                context.States.Update(entity);
            }
            else
            {
                // Borrado físico
                context.States.Remove(entity);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name) AS TextoMostrar
                FROM
                States
                WHERE DeleteAt IS NULL
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<State> GetById(int id)
        {
            var sql = @"SELECT * FROM States WHERE Id = @Id AND DeleteAt IS NULL ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<State>(sql, new { Id = id });
        }
        public async Task<State> Save(State entity)
        {
            context.States.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(State entity)
        {
            entity.UpdateAt = DateTime.Now;
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<State> GetByName(string name)
        {
            return await this.context.States.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<State>> GetAll()
        {
            var sql = @"
                        SELECT s.*, c.Name AS State 
                        FROM States c 
                        INNER JOIN Countries c ON s.CountriesId = c.Id
                        WHERE s.DeleteAt IS NULL 
                        ORDER BY s.Id ASC";
            return await this.context.QueryAsync<State>(sql);
        }
    }
}
