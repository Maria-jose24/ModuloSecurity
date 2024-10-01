using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class CityBusiness : ICityBusiness
    {
        protected readonly ICityData data;

        public CityBusiness(ICityData data)
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

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            IEnumerable<City> citys = (IEnumerable<City>) await this.data.GetAll();
            var cityDtos = citys.Select(city => new CityDto
            {
                Id = city.Id,
                Name = city.Name,
                Postalcode = city.Postalcode,
                StateId = city.StateId,
                StateName = city.State?.Name

            });
            return cityDtos;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<CityDto> GetById(int id)
        {
            City city = await this.data.GetById(id);
            CityDto cityDto = new CityDto();

            cityDto.Id = city.Id;
            cityDto.Name = city.Name;
            cityDto.Postalcode = city.Postalcode;
            cityDto.StateId = city.StateId;
            return cityDto;
        }
        public City mapearDatos(City city, CityDto entity)
        {
            city.Id = entity.Id;
            city.Name = entity.Name;
            city.Postalcode = entity.Postalcode;
            city.StateId = entity.StateId;
            return city;
        }
        public async Task<City> Save(CityDto entity)
        {
            City city = new City
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            city = this.mapearDatos(city, entity);
            return await this.data.Save(city);
        }

        public async Task Update(CityDto entity)
        {
            City city = await this.data.GetById(entity.Id);
            city.UpdateAt = DateTime.Now.AddHours(-5);
            if (city == null)
            {
                throw new Exception("Registro no encontrado");
            }
            city = this.mapearDatos(city, entity); 
            await this.data.Update(city);
        }
    }
}