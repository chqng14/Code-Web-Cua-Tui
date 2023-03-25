using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace CodeWebCuaTui.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserServices _User;
        private readonly IRoleServices _RoleServices;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _User = new UserServices();
            _RoleServices = new RoleServices();
        }
        //---------------User------------
        public IActionResult ShowAll()
        {
            List<User> User = _User.GetAllUsers();
            return View(User);
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var User = contex.Users.Find(id);
            return View(User);
        }
        public IActionResult Create()
        {
            ViewBag.Role = new SelectList(_RoleServices.GetAllRoles(), "ID", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(User User)
        {

            if (_User.CreateUser(User))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            User User = _User.GetUserById(id);
            return View(User);
        }
        public IActionResult Edit(User User)
        {
            if (_User.UpdateUser(User))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_User.DeleteUser(id))
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
