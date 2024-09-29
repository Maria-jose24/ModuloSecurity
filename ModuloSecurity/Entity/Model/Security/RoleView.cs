namespace Entity.Model.Security
{
    public class RoleView
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public bool State {  get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int ViewId { get; set; }
        public View View { get; set; }
    }
}