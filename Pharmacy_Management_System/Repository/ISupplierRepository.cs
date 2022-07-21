using Pharmacy_Management_System.Model;
using System.Collections.Generic;

namespace Pharmacy_Management_System.Repository
{
    public interface ISupplierRepository
    {
        List<Supplier> ShowAllSuppliers();
        string AddSupplier(Supplier supplier);
        string UpdateSupplier(int supplierId,Supplier supplier);
        Supplier GetSupplier(int supplierId);
        Supplier DeleteSupplier(int supplierId);

    }
}
