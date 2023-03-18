using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace CodeWebCuaTui.Controllers
{
    public class ColorController : Controller
    {
        private readonly ILogger<ColorController> _logger;
        private readonly IColorServices _Color;
        public ColorController(ILogger<ColorController> logger)
        {
            _logger = logger;
            _Color = new ColorServices();
        }
        //---------------Color------------
        public IActionResult ShowAll()
        {
            List<Color> categories = _Color.GetAllColors();
            return View(categories);
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var Color = contex.Colors.Find(id);
            return View(Color);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Color Color)
        {
            if (_Color.CreateColor(Color))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Color Color = _Color.GetColorById(id);
            return View(Color);
        }
        public IActionResult Edit(Color Color)
        {
            if (_Color.UpdateColor(Color))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_Color.DeleteColor(id))
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
