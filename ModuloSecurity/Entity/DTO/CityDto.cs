namespace Entity.DTO
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Postalcode { get; set; }
        public int StateId { get; set; }
        public string ? State { get; set; }
    }
}