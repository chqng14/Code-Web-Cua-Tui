using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.IServices
{
    public interface IImageServices
    {
        public bool CreateImages(Images Images);
        public bool UpdateImages(Images Images);
        public bool DeleteImages(Guid id);
        public List<Images> GetAllImagess();
        public Images GetImagesById(Guid id);
        public List<Images> GetImagesByName(string name);
    }
}
