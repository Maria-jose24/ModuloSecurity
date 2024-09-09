namespace Entity.Model.Security
{
    public class UserRole
    {
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeleteAt { get; set; }

        public bool State {  get; set; }

        //Asociaciones

        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId {  get; set; }

        public Role Role { get; set; }
    }
}
