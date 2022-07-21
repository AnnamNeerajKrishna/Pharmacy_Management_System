using Pharmacy_Management_System.Model;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy_Management_System.Repository
{
    public class SupplierDAL : ISupplierRepository
    {
        private readonly PharmacyContextDb _db;
        public SupplierDAL(PharmacyContextDb db)
        {
            _db = db;
        }
        public string AddSupplier(Supplier supplier)
        {
            _db.SupplierDetails.Add(supplier);
            _db.SaveChanges();
            return "Supplier Added Successfully";
                
        }

        public Supplier DeleteSupplier(int supplierId)
        {
            var item = _db.SupplierDetails.FirstOrDefault(c => c.SupplierId == supplierId);
            if (item != null)
            {
                _db.SupplierDetails.Remove(item);
                _db.SaveChanges();
                
            }
            return item;

        }

        public Supplier GetSupplier(int supplierId)
        {
            return _db.SupplierDetails.FirstOrDefault(c => c.SupplierId == supplierId);
            
        }

        public List<Supplier> ShowAllSuppliers()
        {
            var list=_db.SupplierDetails.ToList();
            return list;
        }

        public string UpdateSupplier(int supplierId,Supplier supplier)
        {
            var item = _db.SupplierDetails.FirstOrDefault(c => c.SupplierId == supplierId);
            if (item != null)
            {
                _db.Entry(item).CurrentValues.SetValues(supplier);
                _db.SaveChanges();
            }
            return "Updated Successfully";
        }
    }
}
