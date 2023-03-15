using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;

namespace CodeWebCuaTui.Services
{
    public class ColorServices : IColorServices
    {
        CodeWebCuaTuiDbContex _context;
        public ColorServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }
        public bool CreateColor(Color p)
        {
            try
            {
                _context.Colors.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteColor(Guid id)
        {
            try
            {
                var p = _context.Colors.Find(id);
                _context.Colors.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Color> GetAllColors()
        {
            return _context.Colors.ToList();
        }

        public Color GetColorById(Guid id)
        {
            return _context.Colors.FirstOrDefault(p => p.ID == id);
        }

        public List<Color> GetColorByName(string name)
        {
            return _context.Colors.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateColor(Color p)
        {
            try
            {
                var a = _context.Colors.Find(p.ID);
                a.Code = p.Code;
                a.Name = p.Name;
                a.Status = p.Status;

                _context.Colors.Update(a);
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
