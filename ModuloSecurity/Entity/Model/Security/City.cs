namespace Entity.Model.Security
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Postalcode { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ? UpdateAt { get; set; }
        public DateTime ? DeleteAt { get; set; }
        //Asociaciones
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
    