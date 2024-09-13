using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Implements
{
    public class UserData : IUserData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public UserData(ApplicationDBContext context, IConfiguration configuration)
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
                // Borrado lógico
                entity.DeleteAt = DateTime.Now;
                context.Users.Update(entity);
            }
            else
            {
                // Borrado físico
                context.Users.Remove(entity);
            }

            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-', Description) AS TextoMostrar
                FROM
                Users
                WHERE DeletedAt IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);

        }
        public async Task<User> GetById(int id)
        {
            var sql = @"SELECT * FROM Users WHERE Id = @Id AND DeleteAt IS NULL ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
        }
        public async Task<User> Save(User entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(User entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
        public async Task<User> GetByName(string username)
        {
            return await this.context.Users.AsNoTracking().Where(item => item.Username == username).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            var sql = @"SELECT * FROM Users ORDER BY Id ASC";
            return await this.context.QueryAsync<User>(sql);
        }

    }
}