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

        public IActionResult Pay(string name, string address, string phone, string Describe)
        {
            var UserID = _userServices.GetUserByName(HttpContext.Session.GetString("acc"))[0].ID;
            var listCartDetails = _CartDetails.GetAllCartDetailss().Where(c => c.UserID == UserID);
            decimal tongtien = listCartDetails.Sum(c => c.Quantity * c.Product.Price);
            var Chuoi = "";
            var outOfStockProducts = listCartDetails
                             .Where(item => item.Quantity > productServices.GetProductById(item.ProductId).Quantity)
                             .Select(item => '"' + productServices.GetProductById(item.ProductId).Name);
            Chuoi = string.Join(" ", outOfStockProducts);

            if (listCartDetails.Any())
            {
                if (Chuoi == "")
                {
                    var bill = new Bill()
                    {
                        ID = new Guid(),
                        DateCreate = DateTime.Now,
                        DateOfPay = DateTime.Now,
                        UserID = UserID,
                        Name = name,
                        Phone = phone,
                        Address = address,
                        Describe = Describe,
                        TotalAmount = tongtien,
                        Status = 0
                    };
                    _Bill.CreateBill(bill);
                    foreach (var item in listCartDetails)
                    {
                        _billDetails.CreateBillDetails(new BillDetails()
                        {
                            ID = new Guid(),
                            BillID = bill.ID,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Price = tongtien
                        });
                        _CartDetails.DeleteCartDetails(item.ID);
                        var product = productServices.GetProductById(item.ProductId);
                        product.Quantity -= item.Quantity;
                        productServices.UpdateProduct(product);
                    }
                    TempData["successful"] = "Thanh toán thanh toán thành công";
                    var cartDetailss = _CartDetails.GetAllCartDetailss().Where(c => c.UserID == UserID).ToList();
                    HttpContext.Session.SetString("CartDetailsUser", cartDetailss.Count().ToString());
                    return RedirectToAction("ShowCartUser", "Cart");
                }
                else
                {
                    TempData["PayError"] = "Thanh toán không thành công do số lượng tồn của " + Chuoi + " không đủ !!!";

                }
            }
            return RedirectToAction("ShowCartUser", "Cart");
        }
        public IActionResult PayForNoUser(string name, string address, string phone, string Describe)
        {
            Guid idUser = Guid.Parse("8896ec84-ce69-4b53-a984-efc05024d0ad");
            var lstCartDetails = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");
            if (lstCartDetails != null)
            {
                decimal tongtien = lstCartDetails.Sum(c => c.Quantity * c.Price);
                var Chuoi = "";
                var outOfStockProducts = lstCartDetails
                                 .Where(item => item.Quantity > productServices.GetProductById(item.ProductID).Quantity)
                                 .Select(item => '"' + productServices.GetProductById(item.ProductID).Name);
                Chuoi = string.Join(" ", outOfStockProducts);

                if (lstCartDetails.Any())
                {
                    if (Chuoi == "")
                    {
                        var bill = new Bill()
                        {
                            ID = new Guid(),
                            DateCreate = DateTime.Now,
                            DateOfPay = DateTime.Now,
                            UserID = idUser,
                            Name = name,
                            Phone = phone,
                            Address = address,
                            Describe = Describe,
                            TotalAmount = tongtien,
                            Status = 0
                        };
                        _Bill.CreateBill(bill);
                        foreach (var item in lstCartDetails)
                        {
                            _billDetails.CreateBillDetails(new BillDetails()
                            {
                                ID = new Guid(),
                                BillID = bill.ID,
                                ProductId = item.ProductID,
                                Quantity = item.Quantity,
                                Price = tongtien
                            });
                            var product = productServices.GetProductById(item.ProductID);
                            product.Quantity -= item.Quantity;
                            productServices.UpdateProduct(product);
                        }
                        TempData["successful"] = "Thanh toán thanh toán thành công";
                        HttpContext.Session.Remove("Cart");
                        return RedirectToAction("ShowCart", "Cart");
                    }
                    else
                    {
                        TempData["PayError"] = "Thanh toán không thành công do số lượng tồn của " + Chuoi + " không đủ !!!";

                    }
                }
            }
            return RedirectToAction("ShowCart", "Cart");
        }
        public IActionResult ShowBillForAdmin()
        {
            List<Bill> billList = (_Bill.GetAllBills());
            return View(billList);
        }
        public IActionResult ShowBillForUser()
        {
            var UserID = _userServices.GetUserByName(HttpContext.Session.GetString("acc"))[0].ID;
            List<Bill> billList = (_Bill.GetAllBills().Where(c => c.UserID == UserID)).ToList();
            return View(billList);
        }
        public IActionResult ShowBillDetails(Guid id)
        {
            List<BillDetails> bills = _billDetails.GetAllBillDetails().Where(c => c.BillID == id).ToList();
            return View(bills);
        }
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
