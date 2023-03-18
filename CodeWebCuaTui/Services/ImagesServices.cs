using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;

namespace CodeWebCuaTui.Services
{
    public class ImagesServices : IImageServices
    {
        CodeWebCuaTuiDbContex _context;
        public ImagesServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }
        public bool CreateImages(Images Images)
        {
            try
            {
                _context.Images.Add(Images);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteImages(Guid id)
        {
            try
            {
                var Images = _context.Images.Find(id);
                _context.Images.Remove(Images);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Images> GetAllImagess()
        {
            return _context.Images.ToList();
        }

        public Images GetImagesById(Guid id)
        {
            return _context.Images.FirstOrDefault(p => p.ID == id);
        }

        public List<Images> GetImagesByName(string name)
        {
            return _context.Images.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateImages(Images Images)
        {
            try
            {
                var a = _context.Images.Find(Images.ID);
                a.Name = Images.Name;
                a.Path1 = Images.Path1;
                a.Path2 = Images.Path2;
                a.Path3 = Images.Path3;
                a.Path4 = Images.Path4;
                a.Status = Images.Status;
                _context.Images.Update(a);
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
