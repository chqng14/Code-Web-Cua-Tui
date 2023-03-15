namespace CodeWebCuaTui.Models
{
    public class Role
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public virtual List<User> User { get; set; }
    }
}
