namespace Entity.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool State { get; set; }
        public int PersonId { get; set; }
        public string ? Person { get; set; }
    }
}