namespace Entity.Model.Security
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Postalcode { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeleteAt { get; set; }

        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int StateId { get; set; }

        public State state { get; set; }



    }
}
    