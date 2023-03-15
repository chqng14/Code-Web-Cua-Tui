using CodeWebCuaTui.Models;
using CodeWebCuaTui.IServices;

namespace CodeWebCuaTui.Services
{
    public class BillDetailsServices :IBillDetailsServices
    {
        CodeWebCuaTuiDbContex _context;
        public BillDetailsServices()
        {
            _context = new CodeWebCuaTuiDbContex();
        }

        public bool CreateBillDetails(BillDetails p)
        {
            try
            {
                _context.BillDetails.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteBillDetails(Guid id)
        {
            try
            {
                var p = _context.BillDetails.Find(id);
                _context.BillDetails.Remove(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<BillDetails> GetAllBillDetails()
        {
            return _context.BillDetails.ToList();
        }

        public BillDetails GetBillDetailsById(Guid id)
        {
            return _context.BillDetails.FirstOrDefault(p => p.ID == id);
        }

        public List<BillDetails> GetBillDetailsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBillDetails(BillDetails p)
        {
            try
            {
                var a = _context.BillDetails.Find(p.ID);
             
                _context.BillDetails.Update(a);
                a.BillID = p.ID;
                a.ProductDetailsId=p.ProductDetailsId;
                a.Quantity=p.Quantity;
                a.Price=p.Price;
                a.Status=p.Status;
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
