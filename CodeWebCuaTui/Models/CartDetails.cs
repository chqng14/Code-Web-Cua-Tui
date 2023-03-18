﻿namespace CodeWebCuaTui.Models
{
    public class CartDetails
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }

        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
