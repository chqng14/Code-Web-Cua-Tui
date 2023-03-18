namespace CodeWebCuaTui.Models
{
    public class Images
    {
        public Guid ID { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Path1 { get; set; }
        public string Path2 { get; set; }
        public string Path3 { get; set; }
        public string Path4 { get; set; }
        public int Status { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}
