using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.ViewModel
{
    public class ProductCategoryModel
    {
        public string CategoryName { get; set; }
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Category> categories { get; set; }
    }
}
