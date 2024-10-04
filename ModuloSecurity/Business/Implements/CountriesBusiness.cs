using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;
using System.Diagnostics.Metrics;

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
        public async Task LogicalDelete(int id)
        {
            await this.data.LogicalDelete(id);
        }

        public async Task<IEnumerable<CountriesDto>> GetAll()
        {
           IEnumerable<CountriesDto> countries = await this.data.GetAll();
            /*var countriesDto = countries.Select(countries => new CountriesDto
           {
               Id = countries.Id,
               Name = countries.Name,
           });*/
            return countries;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<CountriesDto> GetById(int id)
        {
            Countries country = await this.data.GetById(id);
            CountriesDto countryDto = new CountriesDto();

            countryDto.Id = country.Id;
            countryDto.Name = country.Name;
            countryDto.State = country.State;

            return countryDto;
        }
        public Countries mapearDatos(Countries countries, CountriesDto entity)
        {
            countries.Id = entity.Id;
            countries.Name = entity.Name;
            countries.State = entity.State;
            return countries;
        }
        public async Task<Countries> Save(CountriesDto entity)
        {
            Countries countries = new Countries
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            countries = this.mapearDatos(countries, entity);
            return await this.data.Save(countries);
        }
        public async Task Update(CountriesDto entity)
        {
            Countries countries = await this.data.GetById(entity.Id);
            countries.UpdateAt = DateTime.Now.AddHours(-5);
            if (countries == null)
            {
                throw new Exception("Registro no encontrado");
            }
            countries = this.mapearDatos(countries, entity);
            await this.data.Update(countries);
        }
    }
}