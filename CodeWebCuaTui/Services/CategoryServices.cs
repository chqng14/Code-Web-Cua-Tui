using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;
using Microsoft.EntityFrameworkCore;

namespace CodeWebCuaTui.Services
{
    
    public class CategoryServices :ICategoryServices
    {
        CodeWebCuaTuiDbContex _context;
        public CategoryServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }

        public bool CreateCategory(Category p)
        {
            try
            {
                _context.Categories.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCategory(Guid id)
        {
            try
            {
                var p = _context.Categories.Find(id);
                _context.Categories.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Category> GetAllCategorys()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(Guid id)
        {
            return _context.Categories.FirstOrDefault(p => p.ID == id);
        }

        public List<Category> GetCategoryByName(string name)
        {
            return _context.Categories.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateCategory(Category p)
        {
            try
            {
                var a = _context.Categories.Find(p.ID);
                a.Code = p.Code;
                a.Name = p.Name;
                a.Status = p.Status;

                _context.Categories.Update(a);
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
