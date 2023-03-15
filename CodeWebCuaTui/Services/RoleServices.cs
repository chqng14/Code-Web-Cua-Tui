using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;

namespace CodeWebCuaTui.Services
{
    public class RoleServices : IRoleServices
    {
        CodeWebCuaTuiDbContex _context;
        public RoleServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }
        public bool CreateRole(Role p)
        {
            try
            {
                _context.Roles.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteRole(Guid id)
        {
            try
            {
                var p = _context.Roles.Find(id);
                _context.Roles.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(Guid id)
        {
            return _context.Roles.FirstOrDefault(p => p.ID == id);
        }

        public List<Role> GetRoleByName(string name)
        {
            return _context.Roles.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateRole(Role p)
        {
            try
            {
                var a = _context.Roles.Find(p.ID);
                a.Code = p.Code;
                a.Name = p.Name;
                a.Status = p.Status;

                _context.Roles.Update(a);
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
