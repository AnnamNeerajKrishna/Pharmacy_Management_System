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
using Pharmacy_Management_System.Services;

namespace Pharmacy_Management_System.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _context;

        public OrdersController(OrderService context)
        {
            _context = context;
        }
        [Authorize(Roles = "administrator")]
        // GET: api/Orders
        [HttpGet]
        public IActionResult GetOrdersDetails()
        {
            List<Orders> orders;
            orders = _context.GetAllOrder().ToList();
            return Ok(orders);
        }
        [Authorize(Roles = "administrator")]
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public IActionResult GetOrders(int id)
        {
            var item = _context.GetOrderById(id);
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
        [Authorize(Roles = "administrator")]
        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrders(int id, Orders orders)
        {
            if(id != orders.OrderId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.UpdateOrder(id, orders);
            return Ok(orders);
        }
        [Authorize]
        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostOrders(Orders order)
        {

            var item = _context.AddOrder(order);
            if (item != null)
            {
                return Ok(order);
            }
            return BadRequest();
        }

        // DELETE: api/Orders/5
        [Authorize(Roles = "administrator")]
        [HttpDelete("{id}")]
        public IActionResult DeleteOrders(int id)
        {
            var supplier = _context.GetOrderById(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.DeleteOrder(id);


            return Ok("Drug is Removed successfully");
        }

       
    }
}
