using System.Linq;
using System;
using Pharmacy_Management_System.Model;

namespace Pharmacy_Management_System.Repository
{
    public class DoctorDAL : IDoctorRepository
    {
        private readonly PharmacyContextDb _db;
      
        public DoctorDAL(PharmacyContextDb db)
        {
            _db = db;
        }

        public void AddDoctor(Doctor doctor)
        {
            _db.DoctorsDetails.Add(doctor);
            _db.SaveChanges();
            
        }

       
    }
}
