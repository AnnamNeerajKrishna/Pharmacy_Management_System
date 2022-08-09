using Pharmacy_Management_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Pharmacy_Management_System.Repository
{
    public class OrdersDAL : IOrdersRepository
    {
        private readonly PharmacyContextDb _db;
        public OrdersDAL(PharmacyContextDb db)
        {
                _db=db; 
        }

        public string AddOrder(Orders order)
        {
           _db.OrdersDetails.Add(order);
            _db.SaveChanges();
            return "Order added to the database";
        }

        public void DeleteOrder(int id)
        {
            try
            {
                var item = _db.OrdersDetails.FirstOrDefault(c => c.OrderId == id);
                if (item != null)
                {

                    _db.OrdersDetails.Remove(item);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Orders> GetAllOrder()
        {
            List<Orders> list = new List<Orders>();
            try
            {
                list = _db.OrdersDetails.ToList();
                return list;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public Orders GetOrderById(int id)
        {
           var item =_db.OrdersDetails.FirstOrDefault(c=>c.OrderId == id);
            return item;
        }

        public void UpdateOrder(int id, Orders order)
        {
            var item = new Orders();
            try
            {
                item = _db.OrdersDetails.FirstOrDefault(d => d.OrderId == id);
                if (item != null)
                {
                    _db.Entry(item).CurrentValues.SetValues(order);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                item = null;
            }
        }
    }
}
