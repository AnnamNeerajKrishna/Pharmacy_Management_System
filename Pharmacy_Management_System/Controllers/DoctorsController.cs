using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy_Management_System;
using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;
using Pharmacy_Management_System.Services;

namespace Pharmacy_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        DoctorService _context;

        public DoctorsController(DoctorService context)
        {
            _context = context;
        }

        [HttpPost("DoctorRegistration")]
      //  [Authorize]
        public IActionResult PostDoctor(Doctor doctor)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.AddDoctor(doctor);
            return Ok("true");

        }
       
    }
}
