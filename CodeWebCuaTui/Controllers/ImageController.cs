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
        public async Task<IActionResult> CreateAsync(Images Image)
        {
            var file1 = Request.Form.Files["image1"];
            var file2 = Request.Form.Files["image2"];
            var file3 = Request.Form.Files["image3"];
            var file4 = Request.Form.Files["image4"];
            string sourcePath1 = file1.FileName;
            string sourcePath2 = file2.FileName;
            string sourcePath3 = file3.FileName;
            string sourcePath4 = file4.FileName;
            Image.Path1 = sourcePath1;
            Image.Path2 = sourcePath2;
            Image.Path3 = sourcePath3;
            Image.Path4 = sourcePath4;
            if (_Image.CreateImages(Image))
            {
                string destinationPath = @"D:\CodeWebCuaTui - Copy\CodeWebCuaTui\wwwroot\Image\";
                string fileName1 = Path.GetFileName(sourcePath1);
                string fileName2 = Path.GetFileName(sourcePath2);
                string fileName3 = Path.GetFileName(sourcePath3);
                string fileName4 = Path.GetFileName(sourcePath4);
                string destinationFilePath1 = Path.Combine(destinationPath, fileName1);
                string destinationFilePath2 = Path.Combine(destinationPath, fileName2);
                string destinationFilePath3 = Path.Combine(destinationPath, fileName3);
                string destinationFilePath4 = Path.Combine(destinationPath, fileName4);
                using (var stream = new FileStream(destinationFilePath1, FileMode.Create))
                {
                    await file1.CopyToAsync(stream);

                }
                using (var stream = new FileStream(destinationFilePath2, FileMode.Create))
                {
                    await file2.CopyToAsync(stream);

                }
                using (var stream = new FileStream(destinationFilePath3, FileMode.Create))
                {
                    await file3.CopyToAsync(stream);

                }
                using (var stream = new FileStream(destinationFilePath4, FileMode.Create))
                {
                    await file4.CopyToAsync(stream);

                }
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
