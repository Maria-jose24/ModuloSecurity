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
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.DeleteAt = DateTime.Parse(DateTime.Today.ToString());
            context.States.Remove(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-',) AS TextoMostrar
                FROM
                State
                WHERE DeletedAt IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<State> GetById(int id)
        {
            var sql = @"SELECT * FROM State WHERE Id = @Id ORDER BY Id ASC";
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
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<State> GetByName(string name)
        {
            return await this.context.States.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<State>> GetAll()
        {
            var sql = @"SELECT * FROM State ORDER BY Id ASC";
            return await this.context.QueryAsync<State>(sql);
        }
    }
}
