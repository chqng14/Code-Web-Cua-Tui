using CodeWebCuaTui.Models;
using CodeWebCuaTui.ViewModel;
using Newtonsoft.Json;

namespace CodeWebCuaTui.Services
{
    public class SessionServices
    {
        public static List<CartItemViewModel> GetObjFromSession(ISession session, string key)
        {
            //Lấy string Json từ Session
            var jsonData = session.GetString(key);
            if (jsonData == null) return new List<CartItemViewModel>();
            //Chuyển đổi dữ liệu vừa lấy được sang dạng mong muốn.
            var Carts = JsonConvert.DeserializeObject<List<CartItemViewModel>>(jsonData);// nếu null trả về một list rỗng
            return Carts;
        }
        public static void SetObjToSession(ISession session, string key, object values)
        {
            var jsonData = JsonConvert.SerializeObject(values);
            session.SetString(key, jsonData);
        }
        public static bool CheckObjInList(Guid id, List<CartItemViewModel> carts)
        {
            return carts.Any(x => x.ProductID == id);
        }
    }
}
