using Business.Interface;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Business.Implements
{
    public class UserBusiness : IUserBusiness
    {
        protected readonly IUserData data;

        public UserBusiness(IUserData data)
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
        public async Task<IEnumerable<UserDto>>GetAll()
        {
            IEnumerable<User>users = (IEnumerable<User>)await this.data.GetAll();
            var userDtos = users.Select(user => new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                State = user.State,
                PersonEmail = user.Person?.Email
            });
            return userDtos;
        }
        public async Task<IEnumerable<DataSelectDto>>GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }
        public async Task<UserDto>GetById(int id)
        {
            User user = await this.data.GetById(id);
            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.Username = user.Username;
            userDto.Password = user.Password;
            userDto.State = user.State;
            return userDto;
        }
        public User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.State = entity.State;
            return user;
        }
        public async Task<User>Save(UserDto entity)
        {
            User user = new User
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            user = this.mapearDatos(user, entity);
            return await this.data.Save(user);
        }
        public async Task Update(UserDto entity)
        {
            User user = await this.data.GetById(entity.Id);
            user.UpdateAt = DateTime.Now.AddHours(-5);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = this.mapearDatos(user, entity);
            await this.data.Update(user);
        }
    }
}