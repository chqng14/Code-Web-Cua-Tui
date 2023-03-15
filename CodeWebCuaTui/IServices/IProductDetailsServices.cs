using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.IServices
{
    public interface IProductDetailsServices
    {
        public bool CreateProductDetails(ProductDetails p);
        public bool UpdateProductDetails(ProductDetails p);
        public bool DeleteProductDetails(Guid id);
        public List<ProductDetails> GetAllProductDetailss();
        public ProductDetails GetProductDetailsById(Guid id);
        public List<ProductDetails> GetProductDetailsByName(string name);
    }
}
