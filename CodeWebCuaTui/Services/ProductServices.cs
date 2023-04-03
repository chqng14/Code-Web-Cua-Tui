using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;

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
                p.ProductCode = Matt();
                _context.Product.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public string Matt()
        {
            if (_context.Product.Count() == 0)
            {
                return "Mixi1";
            }
            else return "Mixi" + _context.Product.Max(c => Convert.ToInt32(c.ProductCode.Substring(4, c.ProductCode.Length - 4)) + 1);
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

            return _context.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                        .Include("Suppliers").ToList();
        }

        public Product GetProductById(Guid id)
        {
            return _context.Product.FirstOrDefault(p => p.ID == id);
        }

        public List<Product> GetProductByName(string name)
        {
            return _context.Product.Where(c => c.Name.Contains(name)).ToList();
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
