namespace CodeWebCuaTui.Models
{
    public class Category
    {
        public Guid ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public virtual List<ProductDetails> ProductDetails{ get; set; }
    }
}
