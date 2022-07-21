using Pharmacy_Management_System.Model;
using System;
using System.Linq;

namespace Pharmacy_Management_System.Repository
{
    public class AdminDAL : IAdminRepository
    {
        private readonly PharmacyContextDb _db;

        public AdminDAL(PharmacyContextDb db)
        {
            _db = db;
        }
        public Doctor GetDoctor(String doctorID)
        {
            var item = _db.DoctorsDetails.FirstOrDefault(c => c.DoctorId == doctorID);
            return item;
        }
    }
}
