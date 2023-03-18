using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;

namespace CodeWebCuaTui.Services
{
    public class ProductServices : IProductServices
    {
        CodeWebCuaTuiDbContex _context;
        public ProductServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }
        public bool CreateProduct(Product p)
        {
            try
            {
                _context.Product.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var p = _context.Product.Find(id);
                _context.Product.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            List<Product> lst = new List<Product>();

            return _context.Product.ToList();
        }

        public Product GetProductById(Guid id)
        {
            return _context.Product.FirstOrDefault(p => p.ID == id);
        }

        public List<Product> GetProductByName(string name)
        {
            return _context.Product.Where(c=>c.Name.Contains(name)).ToList();
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                var a = _context.Product.Find(p.ID);
                a.ColorID = p.ColorID;
                a.SizeID = p.SizeID;
                a.ProductCode = p.ProductCode;
                a.Name = p.Name;
                a.SupplierID = p.SupplierID;
                a.CategoryID = p.CategoryID;
                a.ProductCode = p.ProductCode;
                a.Describe = p.Describe;
                a.Quantity = p.Quantity;
                a.Price = p.Price;
                a.ImageID = p.ImageID;
                a.Status = p.Status;
                _context.Product.Update(a);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
