using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Management_System.Repository;
using Pharmacy_Management_System.Services;

namespace Pharmacy_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        AdminService _context;
        public AdminController(AdminService context)
        {
            _context = context;
        }
        // GET: api/Doctors/5
        [HttpGet("SearchDoctor/{id}")]
        public IActionResult GetDoctor(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.GetDoctor(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }
    }
}
