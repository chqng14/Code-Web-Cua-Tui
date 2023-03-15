namespace CodeWebCuaTui.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public Guid RoleID { get; set; }
        public string Code { get; set; }   
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Bill> Bills { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
