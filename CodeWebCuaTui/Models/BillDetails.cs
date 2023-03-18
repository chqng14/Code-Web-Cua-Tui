namespace CodeWebCuaTui.Models
{
    public class BillDetails
    {
        public Guid ID { get; set; }
        public Guid BillID { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
        public virtual Product Product { get; set; }
        public virtual Bill Bill { get; set; }
    }
}
