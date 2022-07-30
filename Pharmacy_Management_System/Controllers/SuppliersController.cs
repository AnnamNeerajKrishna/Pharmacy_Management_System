using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierDAL _context;

        public SuppliersController(SupplierDAL context)
        {
            _context = context;
        }

        // GET: api/Suppliers
        [HttpGet("GetAllSuppliers")]
        [Authorize(Roles = "administrator")]
        public IActionResult ShowAllSupplier()
        {
            /*var CurrentUser = GetCurrentUser();*/

            List<Supplier> suppliers;
            suppliers = _context.ShowAllSuppliers();
            return Ok(suppliers);
            //return Ok("Hai"+CurrentUser.AdminName);
           
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult GetSupplier(int id)
        {
             if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.GetSupplier(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        //// PUT: api/Suppliers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult PutSupplier(int id, Supplier supplier)
        {
           
            if (!ModelState.IsValid)
           {
                return BadRequest(ModelState);
           }
            var item=_context.UpdateSupplier(id, supplier);
            return Ok("Updated Successfully");
        }
        //


        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "administrator")]
        public IActionResult PostSupplier(Supplier supplier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.AddSupplier(supplier);
            

            return Ok("Supplier Added Successfully");

        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult DeleteSupplier(int id)
        {
            var supplier = _context.GetSupplier(id);
           if (supplier == null)
            {
                return NotFound();
            }

            _context.DeleteSupplier(id);
            

            return Ok("Supplier is Removed successfully");
        }
      /*  private Admin GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new Admin
                {
                    AdminName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailId = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Password = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    Contact = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.MobilePhone)?.Value   
                };
            }
            return null;
        }*/

    }
}
