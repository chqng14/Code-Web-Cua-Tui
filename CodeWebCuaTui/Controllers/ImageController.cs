using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace CodeWebCuaTui.Controllers
{
    public class ImageController : Controller
    {
        private readonly ILogger<ImageController> _logger;
        private readonly IImageServices _Image;
        public ImageController(ILogger<ImageController> logger)
        {
            _logger = logger;
            _Image = new ImagesServices();
        }
        //---------------Image------------
        public IActionResult ShowAll()
        {
            List<Images> categories = _Image.GetAllImagess();
            return View(categories);
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var Image = contex.Images.Find(id);
            return View(Image);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Images Image)
        {
            if (_Image.CreateImages(Image))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Images Image = _Image.GetImagesById(id);
            return View(Image);
        }
        public IActionResult Edit(Images Image)
        {
            if (_Image.UpdateImages(Image))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_Image.DeleteImages(id))
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
