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
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            if (entity == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            // Corregido: Asignación correcta de la propiedad DeleteAt
            entity.DeleteAt = DateTime.Today;
            context.Persons.Remove(entity);
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
            context.Persons.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(First_name ' ', Last_name) AS TextoMostrar
                FROM
                persons
                WHERE DeletedAt IS NULL State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            var sql = @"
                SELECT *
                FROM persons
                INNER JOIN city_residence c ON p.CityId = c.Id 
                WHERE p.DeleteAt IS NULL
                ORDER BY p.Id ASC";
            return await this.context.QueryAsync<PersonDto>(sql);
        }



        public async Task<Person> GetById(int id)
        {
            var sql = @"SELECT * FROM persons WHERE Id = @Id AND DeleteAt IS NULL ORDER BY Id ASC";
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
    }
}