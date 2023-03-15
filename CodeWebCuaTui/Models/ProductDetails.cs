namespace CodeWebCuaTui.Models
{
    public class ProductDetails
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public Guid ColorID { get; set; }
        public Guid SizeID { get; set; }
        public Guid SupplierID { get; set; }
        public Guid CategoryID { get; set; }
        public string ProductCode { get; set; }
        public string Describe { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
        public virtual Supplier Suppliers { get; set; }
        public virtual Color Color { get; set; }
        public virtual Size Sizes { get; set; }
        public virtual List<Images> Images { get; set; }
        public virtual List<CartDetails> CartDetails { get; set; }
        public virtual List<BillDetails> BillDetails { get; set; }
    }
}
