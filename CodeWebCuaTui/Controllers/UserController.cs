using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace CodeWebCuaTui.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserServices _User;
        private readonly IRoleServices _RoleServices;
        private CodeWebCuaTuiDbContex contex;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            _User = new UserServices();
            _RoleServices = new RoleServices();
            contex = new CodeWebCuaTuiDbContex();
        }
        //---------------User------------
        public IActionResult ShowAll()
        {
            var User = contex.Users.Include("Role").ToList();
            return View(User);
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var User = contex.Users.Find(id);
            return View(User);
        }
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                var data = contex.Users.Where(s => s.UserName.Equals(username) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add Session
                    HttpContext.Session.SetString("acc", data.FirstOrDefault().UserName);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
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
            ViewBag.Role = new SelectList(_RoleServices.GetAllRoles(), "ID", "Name");
            User User = _User.GetUserById(id);
            return View(User);
        }
        public IActionResult Edit(User User)
        {
            ViewBag.Role = new SelectList(_RoleServices.GetAllRoles(), "ID", "Name");
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
