using Pharmacy_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pharmacy_Management_System.Repository
{
    public class SupplierDAL : ISupplierRepository
    {
        private readonly PharmacyContextDb _db;

        public SupplierDAL()
        {
        }

        public SupplierDAL(PharmacyContextDb db)
        {
            _db = db;
        }
        /// <summary>
        /// Adding new supplier by Admin
        /// </summary>
        /// <param name="supplier"></param>
        /// <returns></returns>
        #region AddSupplier

        public string AddSupplier(Supplier supplier)
        {
            try
            {
                _db.SupplierDetails.Add(supplier);
                _db.SaveChanges();
                return "Supplier Added Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DeleteSupplier
        /// <summary>
        /// To Deleting the Existing Supplier
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
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
        #endregion
       
        #region GetSupplier
        /// <summary>
        /// Get all the Suppliers present
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        
        public Supplier GetSupplier(int supplierId)
        {
            try
            {
                return _db.SupplierDetails.FirstOrDefault(c => c.SupplierId == supplierId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        public List<Supplier> ShowAllSuppliers()
        {
            try
            {
                var list = _db.SupplierDetails.ToList();
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Updating the Supplier
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="supplier"></param>
        /// <returns></returns>
        /// 
        #region UpdateSupplier
        public string UpdateSupplier(int supplierId,Supplier supplier)
        {
            try
            {
                var item = _db.SupplierDetails.FirstOrDefault(c => c.SupplierId == supplierId);
                if (item != null)
                {
                    _db.Entry(item).CurrentValues.SetValues(supplier);
                    _db.SaveChanges();
                }
                return "Updated Successfully";
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
