﻿using System;
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
    [Authorize]
    [Route("api/[controller]")]
    
    [ApiController]
    

    public class DrugsController : ControllerBase
    {
        private readonly DrugService _context;

        public DrugsController(DrugService context)
        {
            _context = context;
        }

        // GET: api/Drugs
        [HttpGet]
        public IActionResult GetDrugDetails()
        {

            List<Drugs> drugs;
            drugs = _context.GetAllDrugs();
            return Ok(drugs);
        }

        // GET: api/Drugs/5
        [HttpGet("{id}")]
        public IActionResult GetDrugs(int id)
        {
            var item= _context.GetDrugById(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(item);
            }

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        // PUT: api/Drugs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutDrugs(int id, Drugs drugs)
        {
            if (id != drugs.DrugId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.UpdateDrug(id, drugs);
            return Ok("Updated Successfully");
        }

        // POST: api/Drugs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostDrugs(Drugs drugs)
        {

            var item = _context.AddDrug(drugs);
            if (item != null)
            {
                return Ok("New Drug is Been Added");
            }
            return NotFound("Check the details");
        }

        // DELETE: api/Drugs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDrugs(int id)
        {
            var supplier = _context.GetDrugById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.DeleteDrug(id);


            return Ok("Drug is Removed successfully");
        }

        
    }
}
