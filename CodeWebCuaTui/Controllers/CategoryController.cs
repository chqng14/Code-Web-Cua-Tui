using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace CodeWebCuaTui.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryServices _category;
        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
            _category = new CategoryServices();
        }
        //---------------Category------------
        public IActionResult ShowAll()
        {
            List<Category> categories = _category.GetAllCategorys();
            return View(categories);
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var category = contex.Categories.Find(id);
            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (_category.CreateCategory(category))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Category category = _category.GetCategoryById(id);
            return View(category);
        }
        public IActionResult Edit(Category category)
        {
            if (_category.UpdateCategory(category))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_category.DeleteCategory(id))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
