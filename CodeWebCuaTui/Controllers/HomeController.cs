using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using CodeWebCuaTui.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace CodeWebCuaTui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _Product;
        private readonly ICategoryServices _Category;
        private CodeWebCuaTuiDbContex contex;
        private List<Product> _lstproduct;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _Product = new ProductServices();
            _Category = new CategoryServices();
            contex = new CodeWebCuaTuiDbContex();
        }

        public IActionResult Index()
        {

            //lay 2 lst sp de hien thi tam thoi 
            var Product1 = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                   .Include("Suppliers").Take(4).ToList();
            var Product2 = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                        .Include("Suppliers").OrderByDescending(c => c.Price).Take(4).ToList();
            ViewBag.Product1 = Product1;
            ViewBag.Product2 = Product2;
            string acc = HttpContext.Session.GetString("acc");
            if (acc != null)
            {

                return View();
            }
            else
            {

                return View();
            }


        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var Product = contex.Product.Where(c => c.ID == id).Include("Color").Include("Images").Include("Sizes").Include("Category").Include("Suppliers").FirstOrDefault();
            return View(Product);
            //var Product = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
            // .Include("Suppliers").FirstOrDefault(c => c.ID == id);
            return View(Product);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Login()
        {

            return View();
        }
        public IActionResult SignUp()
        {

            return View();
        }
        public IActionResult ShowAll()
        {
            var viewModel = new ProductCategoryModel
            {
                products = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                        .Include("Suppliers").OrderByDescending(c => c.Price).ToList(),
                categories = contex.Categories.ToList()
            };
            return View(viewModel);
        }

        public IActionResult ForgotPass()
        {

            return View();
        }
        public IActionResult Admin()
        {
            string acc = HttpContext.Session.GetString("acc");
            if (acc != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        public IActionResult ShowProductByCategory(Guid id)
        {
            var viewModel = new ProductCategoryModel
            {
                products = contex.Product.Include(c => c.Color).Include(c => c.Images).Include(c => c.Sizes).Include(c => c.Category).Include(c => c.Suppliers).Where(c => c.CategoryID == id).ToList(),
                categories = contex.Categories.ToList(),
                CategoryName = _Category.GetCategoryById(id).Name
            };
            return View(viewModel);
        }
        //public IActionResult AddToCard(Guid id)
        //{
        //    var product = _Product.GetProductById(id);

        //}
        public IActionResult Cart()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}