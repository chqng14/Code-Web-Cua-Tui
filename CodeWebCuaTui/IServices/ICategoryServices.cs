using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.IServices
{
    public interface ICategoryServices
    {
        public bool CreateCategory(Category p);
        public bool UpdateCategory(Category p);
        public bool DeleteCategory(Guid id);
        public List<Category> GetAllCategorys();
        public Category GetCategoryById(Guid id);
        public List<Category> GetCategoryByName(string name);
    }
}
