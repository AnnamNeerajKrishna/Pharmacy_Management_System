using Pharmacy_Management_System.Model;
using System.Collections.Generic;

namespace Pharmacy_Management_System.Repository
{
    public interface IOrdersRepository
    {
        List<Orders> GetAllOrder();
        Orders GetOrderById(int id);
        void DeleteOrder(int id);
        void UpdateOrder(int id, Orders supplier);
        string AddOrder(Orders supplier);
    }
}
