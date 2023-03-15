using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.IServices
{
    public interface ICartDetailsServices
    {
        public bool CreateCartDetails(CartDetails p);
        public bool UpdateCartDetails(CartDetails p);
        public bool DeleteCartDetails(Guid id);
        public List<CartDetails> GetAllCartDetailss();
        public CartDetails GetCartDetailsById(Guid id);
        public List<CartDetails> GetCartDetailsByName(string name);
    }
}
