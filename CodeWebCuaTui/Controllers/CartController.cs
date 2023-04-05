using CodeWebCuaTui.IServices;
using CodeWebCuaTui.Models;
using CodeWebCuaTui.Services;
using CodeWebCuaTui.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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
        private readonly IUserServices userServices;
        private readonly ICartDetailsServices cartDetailsServices;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
            dbContex = new CodeWebCuaTuiDbContex();
            productServices = new ProductServices();
            _Cart = new CartServices();
            userServices = new UserServices();
            cartDetailsServices = new CartDetailsServices();
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
                    if (productInCart.Quantity + a.Quantity <= product.Quantity)
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
        [HttpPost]
        public IActionResult AddToCartUser(CartItemViewModel model)
        {
            var product = productServices.GetProductById(model.ProductID);
            var acc = HttpContext.Session.GetString("acc");
            var id = userServices.GetAllUsers().FirstOrDefault(c => c.UserName == acc).ID;
            var UserInCart = cartDetailsServices.GetAllCartDetailss().FirstOrDefault(c => c.UserID == id && c.ProductId == product.ID);
            if (UserInCart != null)
            {
                if (UserInCart.Quantity + model.Quantity <= product.Quantity)
                {
                    UserInCart.Quantity += model.Quantity;
                    cartDetailsServices.UpdateCartDetails(UserInCart);
                }
                else
                {
                    UserInCart.Quantity = product.Quantity;
                    cartDetailsServices.UpdateCartDetails(UserInCart);
                    TempData["bug"] = "Trong kho đã hết số lượng sản phẩm mà bạn yêu cầu ";
                    return RedirectToAction("Details", "Home", new { id = UserInCart.ProductId });
                }
            }
            else
            {
                var cartDetails = new CartDetails()
                {
                    UserID = id,
                    ProductId = product.ID,
                    Quantity = model.Quantity,
                };
                cartDetailsServices.CreateCartDetails(cartDetails);
            }
            return RedirectToAction("ShowCartUser");

        }
        public IActionResult ShowCartUser()
        {
            var acc = HttpContext.Session.GetString("acc");
            var id = userServices.GetAllUsers().FirstOrDefault(c => c.UserName == acc).ID;
            List<CartDetails> cartDetails = new(cartDetailsServices.GetAllCartDetailss().Where(c => c.UserID == id).ToList());
            decimal tongtien = cartDetails.Sum(c => c.Quantity * c.Product.Price);
            var totalQuantity = cartDetails.Sum(c => c.Quantity * c.Product.Price);
            ViewBag.Total = totalQuantity;
            return View(cartDetails);
        }
        [HttpPost]
        public IActionResult UpdateCartToUser(Guid idsp, int quantity)
        {
            var acc = HttpContext.Session.GetString("acc");
            var id = userServices.GetAllUsers().FirstOrDefault(c => c.UserName == acc).ID;
            var product = productServices.GetProductById(idsp);
            List<CartDetails> cartDetails = new(cartDetailsServices.GetAllCartDetailss().Where(c => c.UserID == id).ToList());
            var a = cartDetails.Find(x => x.ProductId == idsp && x.UserID == id);

            if (quantity <= product.Quantity)
            {
                a.Quantity = quantity;
            }
            else
            {
                TempData["quantityCart"] = "Số lượng bạn chọn đã đạt mức tối đa của sản phẩm này";
            }
            cartDetailsServices.UpdateCartDetails(a);
            return RedirectToAction("ShowCartUser");
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

        public IActionResult DeleteCart(Guid id)
        {
            var carts = SessionServices.GetObjFromSession(HttpContext.Session, "Cart"); // lấy dữ liệu 
            CartItemViewModel productRemove = carts.FirstOrDefault(c => c.ProductID == id);
            if (productRemove != null)
            {
                carts.Remove(productRemove);
            }
            SessionServices.SetObjToSession(HttpContext.Session, "Cart", carts); // gán lại dữ liệu
            return RedirectToAction("ShowCart", "Cart");
        }
        public IActionResult DeleteAllCart()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("ShowCart", "Cart");
        }

        [HttpPost]
        public IActionResult UpdateCart(CartItemViewModel model, Guid idsp, int quantity)
        {
            var product = productServices.GetProductById(idsp);
            var products = SessionServices.GetObjFromSession(HttpContext.Session, "Cart");
            var a = products.Find(x => x.ProductID == idsp);

            if (quantity <= product.Quantity)
            {
                a.Quantity = quantity;
            }
            else
            {
                TempData["quantityCart"] = "Số lượng bạn chọn đã đạt mức tối đa của sản phẩm này";
            }
            SessionServices.SetObjToSession(HttpContext.Session, "Cart", products);
            return RedirectToAction("ShowCart");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
