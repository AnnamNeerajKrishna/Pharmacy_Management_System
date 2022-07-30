using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Management_System.Model;
using Pharmacy_Management_System.Repository;
using Pharmacy_Management_System.Services;
using System.Linq;
using System.Security.Claims;

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
        [Authorize(Roles = "administrator")]
       [HttpGet("SearchDoctor/{id}")]
        public IActionResult GetDoctor(string id)
        {
            var Currentuser=GetCurrentUser();
            //return Ok("Hai" + Currentuser.AdminName);
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
       
        private Admin GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new Admin
                {
                    AdminName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailID = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Password = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Contact = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.MobilePhone)?.Value
                };
            }
            return null;
        }
    }
}
