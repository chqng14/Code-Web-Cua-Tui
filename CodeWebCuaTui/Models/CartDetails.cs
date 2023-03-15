namespace CodeWebCuaTui.Models
{
    public class CartDetails
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductDetailsId { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }

        public virtual ProductDetails ProductDetails { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
