﻿using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class PersonBusiness :  IPersonBusiness
    {
        protected readonly IPersonData data;

        public PersonBusiness(IPersonData data)
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
        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            IEnumerable<PersonDto> persons = await this.data.GetAll();
            /*var personDtos = persons.Select(person => new PersonDto
            {
                Id = person.Id,
                First_name = person.First_name,
                Last_name = person.Last_name,
                Email = person.Email,
                Address = person.Address,
                Type_document = person.Type_document,
                Document = person.Document,
                Birth_of_date = person.Birth_of_date,
                Phone = person.Phone,
                State = person.State,
                CityId = person.CityId,
                CityName = person.City?.Name
            });*/
            return persons;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<PersonDto> GetById(int id)
        {
            Person person = await this.data.GetById(id);
            PersonDto personDto = new PersonDto();

            personDto.Id = id;
            personDto.First_name = person.First_name;
            personDto.Last_name = person.Last_name;
            personDto.Email = person.Email;
            personDto.Address = person.Address;
            personDto.Type_document = person.Type_document;
            personDto.Document = person.Document;
            personDto.Birth_of_date = person.Birth_of_date;
            personDto.Phone = person.Phone;
            personDto.State = person.State;
            personDto.CityId = person.CityId;
            return personDto;
        }
        public Person mapearDatos(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.Last_name = entity.Last_name;
            person.First_name = entity.First_name;
            person.Email = entity.Email;
            person.Address = entity.Address;
            person.Type_document = entity.Type_document;
            person.Document = entity.Document;
            person.Birth_of_date = entity.Birth_of_date;
            person.Phone = entity.Phone;
            person.State = entity.State;
            person.CityId = entity.CityId;
            return person;
        }
        public async Task<Person>Save(PersonDto entity)
        {
            Person person = new Person
            {
                CreateAt = DateTime.Now.AddHours(-5)

            };
            person = this.mapearDatos(person, entity);
            return await this.data.Save(person);
        }
        public async Task Update(PersonDto entity)
        {
            Person person = await this.data.GetById(entity.Id);
            person.UpdateAt = DateTime.Now.AddHours(-5);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }
            person = this.mapearDatos(person,entity);
            await this.data.Update(person);
        }
        
    }
}