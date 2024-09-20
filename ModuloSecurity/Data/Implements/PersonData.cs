using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Implements
{
    public class PersonData : IPersonData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public PersonData(ApplicationDBContext context, IConfiguration configuration)
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

                context.Persons.Update(entity);
            }
            else
            {
                // Borrado físico
                context.Persons.Remove(entity);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(First_name ' ', Last_name) AS TextoMostrar
                FROM
                Persons
                WHERE DeletedAt IS NULL
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<Person> GetById(int id)
        {
            var sql = @"SELECT * FROM Persons WHERE Id = @Id AND DeleteAt IS NULL ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Person>(sql, new { Id = id });
        }
        public async Task<Person> Save(Person entity)
        {
            context.Persons.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(Person entity)
        {
            entity.UpdateAt = DateTime.Now;
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<Person> GetByName(string first_name)
        {
            return await this.context.Persons.AsNoTracking().Where(item => item.First_name == first_name).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Person>> GetAll()
        {
            var sql = @"
                SELECT p.*, c.Name AS City
                FROM Persons p 
                INNER JOIN city_residence c ON p.CityId = c.Id 
                WHERE p.DeleteAt IS NULL
                ORDER BY p.Id ASC";
            return await this.context.QueryAsync<Person>(sql);
        }
    }
}