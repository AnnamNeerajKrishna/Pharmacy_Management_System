using Pharmacy_Management_System.Model;
using System;

namespace Pharmacy_Management_System.Repository
{
    public class OrdersDAL : IOrdersRepository
    {
        private readonly PharmacyContextDb _db;
        public OrdersDAL(PharmacyContextDb db)
        {
                _db=db; 
        }
        public string AddNewOrder(Orders order)
        {
            try
            {
                _db.OrdersDetails.Add(order);
                _db.SaveChanges();
                return "Order is Successfully Added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
