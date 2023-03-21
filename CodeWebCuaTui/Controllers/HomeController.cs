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
            var Product1 = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                       .Include("Suppliers").Take(4).ToList();
            var Product2 = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                        .Include("Suppliers").OrderByDescending(c => c.Price).Take(4).ToList();
            ViewBag.Product1 = Product1;
            ViewBag.Product2 = Product2;
            return View();
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
            var ProductShowAll = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                        .Include("Suppliers").ToList();
            var ProductLocGiaCao = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                        .Include("Suppliers").OrderByDescending(c => c.Price).ToList();
            var ProductLocGiaThap = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                       .Include("Suppliers").OrderBy(c => c.Price).ToList();
            ViewBag.ProductShowAll = ProductShowAll;
            ViewBag.ProductLocGiaCao = ProductLocGiaCao;
            ViewBag.ProductLocGiaThap = ProductLocGiaThap;
            return View();
        }
        public IActionResult AoCoc()
        {
            Guid a = Guid.Parse("622e8e8d-084f-409a-132a-08db26fd3333");
            var Product1 = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                      .Include("Suppliers").Where(c => c.CategoryID == a).ToList();
            var Product2 = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                     .Include("Suppliers").Take(3).ToList();
            ViewBag.Product1 = Product1;
            ViewBag.Product2 = Product2;
            return View();
        }
        public IActionResult AoDai()
        {
            Guid a = Guid.Parse("b68796a0-88d1-4d89-f59c-08db26fd59db");
            var Product1 = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                      .Include("Suppliers").Where(c => c.CategoryID == a).ToList();
            var Product2 = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                     .Include("Suppliers").Take(3).ToList();
            ViewBag.Product1 = Product1;
            ViewBag.Product2 = Product2;
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