using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
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
        private CodeWebCuaTuiDbContex contex;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _Product = new ProductServices();
            contex = new CodeWebCuaTuiDbContex();
        }

        public IActionResult Index()
        {
            var Product = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
               .Include("Suppliers").ToList();
            return View(Product);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var Product = contex.Product.Find(id);
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
        public IActionResult ForgotPass()
        {

            return View();
        }
        public IActionResult Admin()
        {
            return View();
        }
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