namespace CodeWebCuaTui.Models
{
    public class Cart
    {
        public Guid ID { get; set; }
        public string Describe { get; set; }
        public virtual User User { get; set; } 
        public virtual List<CartDetails> CartDetails { get; set; }
    }
}
