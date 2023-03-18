using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace CodeWebCuaTui.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly ISupplierServices _Supplier;
        public SupplierController(ILogger<SupplierController> logger)
        {
            _logger = logger;
            _Supplier = new SupplierServices();
        }
        //---------------Supplier------------
        public IActionResult ShowAll()
        {
            List<Supplier> Supplier = _Supplier.GetAllSuppliers();
            return View(Supplier);
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var Supplier = contex.Suppliers.Find(id);
            return View(Supplier);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier Supplier)
        {
            if (_Supplier.CreateSupplier(Supplier))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Supplier Supplier = _Supplier.GetSupplierById(id);
            return View(Supplier);
        }
        public IActionResult Edit(Supplier Supplier)
        {
            if (_Supplier.UpdateSupplier(Supplier))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_Supplier.DeleteSupplier(id))
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
