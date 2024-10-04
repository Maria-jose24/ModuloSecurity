namespace Entity.Model.Security
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime ? UpdateAt { get; set; }

        public DateTime ? DeleteAt { get; set; }

        public bool State {  get; set; }
        //Asociaciones
        public int PersonId { get; set; }

        public Person  Person { get; set; }

    }
}