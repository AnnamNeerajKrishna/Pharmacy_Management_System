using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;
using System.Collections.Generic;

namespace Pharmacy_Management_System.Services
{
    public class OrderService
    {
        private readonly OrdersDAL _order;
        public OrderService(OrdersDAL order)
        {
            _order = order; 
        }
        public string AddOrder(Orders order)
        {
            _order.AddOrder(order);
            return "Order is Successfully Added";
        }
        public void DeleteOrder(int id)
        {
            _order.DeleteOrder(id);
        }
        public List<Orders> GetAllOrder()
        {
            return _order.GetAllOrder();

        }
        public Orders GetOrderById(int id)
        {
            return _order.GetOrderById(id);  
        }
        public void UpdateOrder(int id, Orders order)
        {
            _order.UpdateOrder(id, order);
        }
    }
}
