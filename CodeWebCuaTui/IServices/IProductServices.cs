using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.IServices
{
    public interface IProductServices
    {
        public bool CreateProducts(Product p);
        public bool UpdateProducts(Product p);
        public bool DeleteProducts(Guid id);
        public List<Product> GetAllProductss();
        public Product GetProductsById(Guid id);
        public List<Product> GetProductsByName(string name);
    }
}
