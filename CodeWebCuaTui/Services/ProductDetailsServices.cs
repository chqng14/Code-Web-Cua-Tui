using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;

namespace CodeWebCuaTui.Services
{
    public class ProductDetailsServices : IProductDetailsServices
    {
        CodeWebCuaTuiDbContex _context;
        public ProductDetailsServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }
        public bool CreateProductDetails(ProductDetails p)
        {
            try
            {
                _context.ProductDetails.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProductDetails(Guid id)
        {
            try
            {
                var p = _context.ProductDetails.Find(id);
                _context.ProductDetails.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<ProductDetails> GetAllProductDetailss()
        {
            return _context.ProductDetails.ToList();
        }

        public ProductDetails GetProductDetailsById(Guid id)
        {
            return _context.ProductDetails.FirstOrDefault(p => p.ID == id);
        }

        public List<ProductDetails> GetProductDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductDetails(ProductDetails p)
        {
            try
            {
                var a = _context.ProductDetails.Find(p.ID);
               a.ProductID=p.ProductID;
                a.ColorID=p.ColorID;
                a.SizeID=p.SizeID;
                a.SupplierID=p.SupplierID;
                a.CategoryID=p.CategoryID;
                a.ProductCode= p.ProductCode;
                a.Describe= p.Describe;
                a.Quantity=p.Quantity;
                a.Price= p.Price;
                a.Status=p.Status;
                _context.ProductDetails.Update(a);
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
