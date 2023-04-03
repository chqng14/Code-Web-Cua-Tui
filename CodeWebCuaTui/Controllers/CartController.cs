using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using CodeWebCuaTui.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
namespace CodeWebCuaTui.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartServices _Cart;
        private readonly CodeWebCuaTuiDbContex dbContex;
        private readonly IProductServices productServices;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
            dbContex = new CodeWebCuaTuiDbContex();
            productServices = new ProductServices();
            _Cart = new CartServices();
        }
        //---------------Cart------------
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(CartItemViewModel a)
        {
            //lấy dữ liệu sản phẩm
            var product = productServices.GetProductById(a.ProductID);
            var categoryName = dbContex.Categories.Where(c => c.ID == product.CategoryID).Select(c => c.Name).FirstOrDefault();
            var ImagePath = dbContex.Images.Where(c => c.ID == product.ImageID).Select(c => c.Path1).FirstOrDefault();
            var Color = dbContex.Colors.Where(c => c.ID == product.ColorID).Select(c => c.Name).FirstOrDefault();
            var Size = dbContex.Sizes.Where(c => c.ID == product.SizeID).Select(c => c.Name).FirstOrDefault();
            int quantity = 1;
            var cartItem = new CartItemViewModel()
            {
                ProductID = product.ID,
                CategoryName = categoryName,
                Quantity = a.Quantity,
                Color = Color,
                Size = Size,
                ProductCode = product.ProductCode,
                Name = product.Name,
                Price = product.Price,
                Image = ImagePath
            };
            //lấy dữ liệu từ Cart(Trong Session)
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");
            var productInCart = products.FirstOrDefault(c => c.ProductID == a.ProductID);
            //Kiểm tra xem dữ liệu đó có phần từ nào chưa....
            if (products.Count == 0)
            {
                products.Add(cartItem); // Nếu không có sản phẩm nào thì add nó vào
                //Sau đó gản lại giá trị vào trong Session
                SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
            }
            else
            {
                if (SessionServices.CheckObjInList(a.ProductID, products))
                {
                    if (productInCart.Quantity < product.Quantity)
                    {
                        productInCart.Quantity += a.Quantity;
                        SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
                    }
                    else
                    {
                        TempData["bug"] = "Trong kho đã hết số lượng sản phẩm mà bạn yêu cầu ";
                        return RedirectToAction("Details", "Home", new { id = productInCart.ProductID });
                    }

                }
                else
                {
                    products.Add(cartItem); // Nếu chưa có sản phẩm đó
                                            //Sau đó gản lại giá trị vào trong Session
                    SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
                }
            }

            return RedirectToAction("ShowCart");
        }
        public IActionResult ShowCart()
        {
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");
            //decimal tongtien = 0;
            decimal tongtien = products.Sum(c => c.Quantity * c.Price);
            //foreach (var item in products)
            //{
            //    tongtien += item.Quantity * item.Price;
            //}
            //ViewBag.Total = tongtien;
            ViewBag.Total = tongtien;

            // tính tổng số lượng sản phẩm trong giỏ hàng
            var totalQuantity = products.Count();
            ViewBag.TotalQuantity = totalQuantity;
            return View(products);
        }
        public IActionResult addQuantity(Guid productId, int quantity)
        {
            // Lấy danh sách sản phẩm trong giỏ hàng từ session
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");

            // Tìm sản phẩm cần thay đổi số lượng
            var product = products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                // Cập nhật số lượng sản phẩm
                product.Quantity = quantity;

                // Lưu lại danh sách sản phẩm vào session
                SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
            }

            return RedirectToAction("ShowCart");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
