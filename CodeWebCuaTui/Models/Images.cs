namespace CodeWebCuaTui.Models
{
    public class Images
    {
        public Guid ID { get; set; }
        public Guid ProductDetailsId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int Status { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}
