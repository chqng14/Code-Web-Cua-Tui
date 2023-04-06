using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;

namespace CodeWebCuaTui.Services
{
    public class UserServices : IUserServices
    {
        CodeWebCuaTuiDbContex _context;
        public UserServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }
        public bool CreateUser(User p)
        {
            try
            {
                p.Code = Matt();
                p.Status = 0;
                _context.Users.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var p = _context.Users.Find(id);
                _context.Users.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public string Matt()
        {
            if (_context.Users.Count() == 0)
            {
                return "USER1";
            }
            else return "USER" + _context.Users.Max(c => Convert.ToInt32(c.Code.Substring(4, c.Code.Length - 4)) + 1);
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(p => p.ID == id);
        }

        public List<User> GetUserByName(string name)
        {
            return _context.Users.Where(p => p.UserName == name).ToList();
        }

        public bool UpdateUser(User p)
        {
            try
            {
                var a = _context.Users.Find(p.ID);
                a.RoleID = p.RoleID;
                a.Code = p.Code;
                a.Name = p.Name;
                a.Phone = p.Phone;
                a.Address = p.Address;
                a.Birthday = p.Birthday;
                a.Email = p.Email;
                a.UserName = p.UserName;
                a.Password = p.Password;
                a.Status = p.Status;

                _context.Users.Update(a);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
