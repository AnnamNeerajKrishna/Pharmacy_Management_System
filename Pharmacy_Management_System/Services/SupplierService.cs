using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;
using System.Collections.Generic;

namespace Pharmacy_Management_System.Services
{
    public class SupplierService
    {
        private readonly SupplierDAL _supplier;
        public SupplierService(SupplierDAL supplier)
        {
            _supplier = supplier;
        }
        public string AddSupplier(Supplier supplier)
        {
            return _supplier.AddSupplier(supplier);
        }
        public Supplier DeleteSupplier(int supplierId)
        {
            return _supplier.DeleteSupplier(supplierId);
        }
        public Supplier GetSupplier(int supplierId)
        {
            return _supplier.GetSupplier(supplierId);
        }
        public List<Supplier> ShowAllSuppliers()
        {
            return _supplier.ShowAllSuppliers();
        }
        public string UpdateSupplier(int supplierId, Supplier supplier)
        {
            return _supplier.UpdateSupplier(supplierId, supplier);
        }

    }
}
