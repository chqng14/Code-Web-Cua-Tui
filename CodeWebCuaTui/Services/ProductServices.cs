using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;
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
        public bool CreateProducts(Product p)
        {
            try
            {
                _context.Products.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProducts(Guid id)
        {
            try
            {
                var p = _context.Products.Find(id);
                _context.Products.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Product> GetAllProductss()
        {
            return _context.Products.ToList();
        }

        public Product GetProductsById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.ID == id);
        }

        public List<Product> GetProductsByName(string name)
        {
            return _context.Products.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateProducts(Product p)
        {
            try
            {
                var a = _context.Products.Find(p.ID);
                a.Code = p.Code;
                a.Name = p.Name;
                a.Status = p.Status;

                _context.Products.Update(a);
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
