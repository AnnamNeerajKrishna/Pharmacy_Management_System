using Pharmacy_Management_System.Model;

namespace Pharmacy_Management_System.Repository
{
    public interface IOrdersRepository
    {
        string AddNewOrder(Orders order);
    }
}
