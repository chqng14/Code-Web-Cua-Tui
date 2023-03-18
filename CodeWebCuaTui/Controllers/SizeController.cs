using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace CodeWebCuaTui.Controllers
{
    public class SizeController : Controller
    {
        private readonly ILogger<SizeController> _logger;
        private readonly ISizeServices _Size;
        public SizeController(ILogger<SizeController> logger)
        {
            _logger = logger;
            _Size = new SizeServices();
        }
        //---------------Size------------
        public IActionResult ShowAll()
        {
            List<Size> Size = _Size.GetAllSizes();
            return View(Size);
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var Size = contex.Sizes.Find(id);
            return View(Size);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Size Size)
        {
            if (_Size.CreateSize(Size))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Size Size = _Size.GetSizeById(id);
            return View(Size);
        }
        public IActionResult Edit(Size Size)
        {
            if (_Size.UpdateSize(Size))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_Size.DeleteSize(id))
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
