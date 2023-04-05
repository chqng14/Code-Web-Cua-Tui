using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace CodeWebCuaTui.Controllers
{
    public class BillController : Controller
    {
        private readonly ILogger<BillController> _logger;
        private readonly IUserServices _userServices;
        private readonly IBillServices _Bill;
        private readonly IBillDetailsServices _billDetails;
        private readonly ICartDetailsServices _CartDetails;
        private readonly IProductServices productServices;

        public BillController(ILogger<BillController> logger)
        {
            _logger = logger;
            _Bill = new BillServices();
            _userServices = new UserServices();
            _billDetails = new BillDetailsServices();
            _Bill = new BillServices();
            _CartDetails = new CartDetailsServices();
            productServices = new ProductServices();
        }
        //---------------Bill------------
        public IActionResult ShowAll()
        {
            List<Bill> categories = _Bill.GetAllBills();
            return View(categories);
        }
        public IActionResult Details(Guid id)
        {
            CodeWebCuaTuiDbContex contex = new CodeWebCuaTuiDbContex();
            var Bill = contex.Categories.Find(id);
            return View(Bill);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Bill Bill)
        {
            if (_Bill.CreateBill(Bill))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            Bill Bill = _Bill.GetBillById(id);
            return View(Bill);
        }
        public IActionResult Edit(Bill Bill)
        {
            if (_Bill.UpdateBill(Bill))
            {
                return RedirectToAction("ShowAll");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (_Bill.DeleteBill(id))
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
