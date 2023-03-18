namespace CodeWebCuaTui.Models
{
    public class Bill
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string BillCode { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateOfPay { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Describe { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public virtual User User { get; set; }

        public virtual List<BillDetails> BillDetails { get; set; }
    }
}
