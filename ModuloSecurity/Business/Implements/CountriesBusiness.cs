using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class CountriesBusiness : ICountriesBusiness
    {
        protected readonly ICountriesData data;

        public CountriesBusiness(ICountriesData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<CountriesDto>> GetAll()
        {
            IEnumerable<Countries> countries = await this.data.GetAll();
            var countriesDtos = countries.Select(countries => new CountriesDto
            {
                Id = countries.Id,
                Name = countries.Name,
            });
            return countriesDtos;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<CountriesDto> GetById(int id)
        {
            Countries countries = await this.data.GetById(id);
            CountriesDto countriesDto = new CountriesDto();

            countriesDto.Id = countries.Id;
            countriesDto.Name = countries.Name;
            return countriesDto;
        }
        public Countries mapearDatos(Countries countries, CountriesDto entity)
        {
            countries.Id = entity.Id;
            countries.Name = entity.Name;
            return countries;
        }
        public async Task<Countries> Save(CountriesDto entity)
        {
            Countries countries = new Countries();
            countries.CreateAt = DateTime.Now.AddHours(-5);
            countries = this.mapearDatos(countries, entity);

            return await this.data.Save(countries);
        }
        public async Task Update(CountriesDto entity)
        {
            Countries countries = await this.data.GetById(entity.Id);
            if (countries == null)
            {
                throw new Exception("Registro no encontrado");
            }
            countries = this.mapearDatos(countries, entity);
            await this.data.Update(countries);
        }
    }
}