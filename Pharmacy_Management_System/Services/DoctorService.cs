using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;

namespace Pharmacy_Management_System.Services
{
    public class DoctorService
    {
        private readonly DoctorDAL _doctor;
        public DoctorService(DoctorDAL doctor)
        {
            _doctor= doctor;
        }
        public void AddDoctor(Doctor doctor)
        {
            _doctor.AddDoctor(doctor);
        }
    }
}
