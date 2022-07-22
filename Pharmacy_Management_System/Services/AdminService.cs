using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;
using System;

namespace Pharmacy_Management_System.Services
{
    public class AdminService
    {
        private readonly AdminDAL _admin;

        public AdminService(AdminDAL admin)
        {
            _admin= admin;
        }
        public Doctor GetDoctor(String doctorID)
        {
            var item = _admin.GetDoctor(doctorID);
            return item;
        }
    }
}
