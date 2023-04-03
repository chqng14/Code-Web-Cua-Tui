using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.ViewModel
{
    public class CartItemViewModel
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public string ProductCode { get; set; }
        public string Color { get; set; }
        public string Size  { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
         public  decimal Price { get; set; }
    }
}
