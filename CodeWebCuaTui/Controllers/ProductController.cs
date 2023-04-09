using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace CodeWebCuaTui.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductServices _Product;
        private readonly IColorServices _ColorService;
        private readonly ICategoryServices _CategoryService;
        private readonly ISupplierServices _SupplierService;
        private readonly ISizeServices _SizeService;
        private readonly IImageServices _ImageService;
        private CodeWebCuaTuiDbContex contex;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            _Product = new ProductServices();
            contex = new CodeWebCuaTuiDbContex();
            _ColorService = new ColorServices();
            _CategoryService = new CategoryServices();
            _SupplierService = new SupplierServices();
            _SizeService = new SizeServices();
            _ImageService = new ImagesServices();
        }
        //---------------Product------------
        public IActionResult ShowAll()
        {
            var Product = contex.Product.Include("Color").Include("Images").Include("Sizes").Include("Category")
                .Include("Suppliers").ToList();
            //if(Product!= null)
            //{
            //    var image = contex.Images.FirstOrDefault(i=>i.pro)
            //}    
            //List<Product> Product = _Product.GetAllProducts();

            return View(Product);
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var Product = contex.Product.Find(id);
            return View(Product);
        }
        public IActionResult Create()
        {
            //ViewBag.Colors = new SelectList(contex.Colors.ToList(), "ID", "Name");
            //ViewBag.Categories = new SelectList(contex.Categories.ToList(), "ID", "Name");
            //ViewBag.Suppliers = new SelectList(contex.Suppliers.ToList(), "ID", "Name");
            //ViewBag.Sizes = new SelectList(contex.Sizes.ToList(), "ID", "Name");
            //ViewBag.Images = new SelectList(contex.Images.ToList(), "ID", "Name");
            ViewBag.Colors = new SelectList(_ColorService.GetAllColors(), "ID", "Name");
            ViewBag.Categories = new SelectList(_CategoryService.GetAllCategorys(), "ID", "Name");
            ViewBag.Suppliers = new SelectList(_SupplierService.GetAllSuppliers(), "ID", "Name");
            ViewBag.Sizes = new SelectList(_SizeService.GetAllSizes(), "ID", "Name");
            ViewBag.Images = new SelectList(_ImageService.GetAllImagess(), "ID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product Product)
        {
            if (_Product.CreateProduct(Product))
            {
                TempData["MessageForCreate"] = "Thêm thành công";
                return RedirectToAction("ShowAll");
            }
            else
            {
                TempData["MessageForCreate"] = "Thêm thất bại do sản phẩm trùng tên";
                return RedirectToAction("Create");
            }

        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            ViewBag.Colors = new SelectList(_ColorService.GetAllColors(), "ID", "Name");
            ViewBag.Categories = new SelectList(_CategoryService.GetAllCategorys(), "ID", "Name");
            ViewBag.Suppliers = new SelectList(_SupplierService.GetAllSuppliers(), "ID", "Name");
            ViewBag.Sizes = new SelectList(_SizeService.GetAllSizes(), "ID", "Name");
            ViewBag.Images = new SelectList(_ImageService.GetAllImagess(), "ID", "Name");
            Product Product = _Product.GetProductById(id);
            return View(Product);
        }
        public IActionResult Edit(Product Product)
        {
            ViewBag.Colors = new SelectList(_ColorService.GetAllColors(), "ID", "Name");
            ViewBag.Categories = new SelectList(_CategoryService.GetAllCategorys(), "ID", "Name");
            ViewBag.Suppliers = new SelectList(_SupplierService.GetAllSuppliers(), "ID", "Name");
            ViewBag.Sizes = new SelectList(_SizeService.GetAllSizes(), "ID", "Name");
            ViewBag.Images = new SelectList(_ImageService.GetAllImagess(), "ID", "Name");
            if (_Product.UpdateProduct(Product))
            {
                TempData["AlertMessage"] = "Cập nhật thành công";
                return RedirectToAction("ShowAll");

            }
            else
            {
                TempData["AlertMessage"] = "Sản phẩm trùng tên";
                return View();
            }

        }
        public IActionResult Delete(Guid id)
        {
            if (_Product.DeleteProduct(id))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public int MyProperty { get; set; }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
