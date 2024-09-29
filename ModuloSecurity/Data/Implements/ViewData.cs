using Data.Interfaces;
using Entity.Context;
using Entity.DTO;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Data.Implements
{
    public class ViewData : IViewData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ViewData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Views.Remove(entity);
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
            context.Views.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT
                Id,
                CONCAT(Name, '-', Description) AS TextoMostrar
                FROM
                views
                WHERE DeletedAt IS NULL AND State = 1
                ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            var sql = @"SELECT
                vi.Id,
                vi.Name,
                vi.Description,
                vi.State,
                vi.ModuloId,
                mo.Description AS DescriptionModulo

                FROM views AS vi
                INNERR JOIN modulos AS mo ON mo.Id = vi.ModuloId
                WHERE IS NULL(vi.DeleteAt)";
            return await this.context.QueryAsync<ViewDto>(sql);
        }
        public async Task<View> GetById(int id)
        { 
            var sql = @"SELECT * FROM views WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<View>(sql, new { Id = id });
        }
        public async Task<View> Save(View entity)
        {
            context.Views.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(View entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}