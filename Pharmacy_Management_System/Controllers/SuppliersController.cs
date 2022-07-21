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
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierDAL _context;

        public SuppliersController(SupplierDAL context)
        {
            _context = context;
        }

        // GET: api/Suppliers
        [HttpGet]
        public IActionResult ShowAllSupplier()
        {
            List<Supplier> suppliers;
            suppliers = _context.ShowAllSuppliers();
            return Ok(suppliers);
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
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

        //private bool SupplierExists(int id)
        //{
        //    return _context.SupplierDetails.Any(e => e.SupplierId == id);
        //}
    }
}
