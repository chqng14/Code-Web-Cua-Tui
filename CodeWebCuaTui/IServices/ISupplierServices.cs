using CodeWebCuaTui.Models;

namespace CodeWebCuaTui.IServices
{
    public interface ISupplierServices
    {
        public bool CreateSupplier(Supplier p);
        public bool UpdateSupplier(Supplier p);
        public bool DeleteSupplier(Guid id);
        public List<Supplier> GetAllSuppliers();
        public Supplier GetSupplierById(Guid id);
        public List<Supplier> GetSupplierByName(string name);
    }
}
