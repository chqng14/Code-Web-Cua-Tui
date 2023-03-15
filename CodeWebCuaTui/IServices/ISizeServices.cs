using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.IServices
{
    public interface ISizeServices
    {
        public bool CreateSize(Size p);
        public bool UpdateSize(Size p);
        public bool DeleteSize(Guid id);
        public List<Size> GetAllSizes();
        public Size GetSizeById(Guid id);
        public List<Size> GetSizeByName(string name);
    }
}
