using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;

namespace CodeWebCuaTui.Services
{
    public class PaymentMethodsServices : IPaymentMethodsServices
    {
        CodeWebCuaTuiDbContex _context;
        public PaymentMethodsServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }
        public bool CreatePaymentMethods(PaymentMethods p)
        {
            try
            {
                _context.PaymentMethods.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePaymentMethods(Guid id)
        {
            try
            {
                var p = _context.PaymentMethods.Find(id);
                _context.PaymentMethods.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<PaymentMethods> GetAllPaymentMethods()
        {
            return _context.PaymentMethods.ToList();
        }

        public PaymentMethods GetPaymentMethodsById(Guid id)
        {
            return _context.PaymentMethods.FirstOrDefault(p => p.ID == id);
        }

        public List<PaymentMethods> GetPaymentMethodsByName(string name)
        {
            return _context.PaymentMethods.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdatePaymentMethods(PaymentMethods p)
        {
            try
            {
                var a = _context.PaymentMethods.Find(p.ID);
                a.Code = p.Code;
                a.Name = p.Name;
                a.Status = p.Status;

                _context.PaymentMethods.Update(a);
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
