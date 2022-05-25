using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICRUDServerApp.Data;

namespace WebAPICRUDServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrdersDetailsContext _context;
        public OrdersController(OrdersDetailsContext context)
        {
            _context = context;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public object Get()
        {
            return new { Items = _context.Orders, Count = _context.Orders.Count() };
        }
        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] Order book)
        {
            _context.Orders.Add(book);
            _context.SaveChanges();
        }
        // PUT api/<OrdersController>
        [HttpPut]
        public void Put(long id, [FromBody] Order book)
        {
            Order _book = _context.Orders.Where(x => x.OrderId.Equals(book.OrderId)).FirstOrDefault();
            _book.CustomerId = book.CustomerId;
            _book.Freight = book.Freight;
            _book.OrderDate = book.OrderDate;
            _context.SaveChanges();
        }
        // DELETE api/<OrdersController>
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            Order _book = _context.Orders.Where(x => x.OrderId.Equals(id)).FirstOrDefault();
            _context.Orders.Remove(_book);
            _context.SaveChanges();
        }
    }
}
