using CodeWebCuaTui.Models;
namespace CodeWebCuaTui.IServices
{
    public interface IPaymentMethodsServices
    {
        public bool CreatePaymentMethods(PaymentMethods p);
        public bool UpdatePaymentMethods(PaymentMethods p);
        public bool DeletePaymentMethods(Guid id);
        public List<PaymentMethods> GetAllPaymentMethods();
        public PaymentMethods GetPaymentMethodsById(Guid id);
        public List<PaymentMethods> GetPaymentMethodsByName(string name);
    }
}
