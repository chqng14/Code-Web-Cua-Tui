using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;

namespace CodeWebCuaTui.Services
{
    public class SizeServices : ISizeServices
    {
        CodeWebCuaTuiDbContex _context;
        public SizeServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }
        public bool CreateSize(Size p)
        {
            try
            {
                _context.Sizes.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSize(Guid id)
        {
            try
            {
                var p = _context.Sizes.Find(id);
                _context.Sizes.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Size> GetAllSizes()
        {
            return _context.Sizes.ToList();
        }

        public Size GetSizeById(Guid id)
        {
            return _context.Sizes.FirstOrDefault(p => p.ID == id);
        }

        public List<Size> GetSizeByName(string name)
        {
            return _context.Sizes.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateSize(Size p)
        {
            try
            {
                var a = _context.Sizes.Find(p.ID);
                a.Code = p.Code;
                a.Name = p.Name;
                a.Status = p.Status;

                _context.Sizes.Update(a);
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
