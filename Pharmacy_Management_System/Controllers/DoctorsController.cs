using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy_Management_System;
using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;

namespace Pharmacy_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
         DoctorDAL _context;

        public DoctorsController(DoctorDAL context)
        {
            _context = context;
        }

        // GET: api/Doctors
      //  [HttpGet]
        //public async IActionResult GetDoctorsDetails()
        //{
            
        //}

       

        // PUT: api/Doctors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDoctor(string id, Doctor doctor)
        //{
            
        //}

        // POST: api/Doctors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostDoctor(Doctor doctor)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.AddDoctor(doctor);
            return Ok("Doctor Added Successfully");

        }

        // DELETE: api/Doctors/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDoctor(string id)
        //{
            
        //}

        //private bool DoctorExists(string id)
        //{
        //    return _context.DoctorsDetails.Any(e => e.DoctorId == id);
        //}
    }
}
