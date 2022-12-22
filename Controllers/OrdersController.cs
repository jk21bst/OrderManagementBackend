using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMS74019FINALCSB.Data.Models;
using OMS74019FINALCSB.Repository;

namespace OMS74019FINALCSB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrders _orderepo;

        public OrdersController(IOrders orderepo)
        {
            _orderepo = orderepo;
        
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            try
            {
                return Ok(await _orderepo.GetOrders());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrievind data from database");
            }

        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetOrder([FromRoute] int id)
        {
            try
            {
                var result = await _orderepo.GetOrderByOrderId(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No Records in the database");
            }

        }


        [HttpGet("cust/{CustId}")]
        public ActionResult<IEnumerable<Orders>> GetOrderByCustId([FromRoute] int CustId)
        {
            try
            {
                var result =  _orderepo.GetOrderByCustId(CustId);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return NotFound();
            }

        }




        // PUT: api/Orders/5
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Orders>> PutOrders([FromRoute] int id, [FromBody] Orders orders)
        {
            try
            {
                if (id != orders.OrderId)
                {
                    return BadRequest($"Order with Id={id} not found");
                }
                var updateOrder = await _orderepo.GetOrderByOrderId(id);
                if (updateOrder == null)
                {
                    return NotFound($"Order with Id={id} not found");
                }
                return await _orderepo.UpdateOrder(orders);
            }
            catch (Exception)
            {
                return NotFound() ;
            }
        }


        // POST: api/Orders
        [HttpPost("addn")]
        public async Task<ActionResult<Orders>> PostOrders([FromBody] Orders orders)
        {
            try
            {
                if (orders == null)
                {
                    return BadRequest();
                }
                var result = await _orderepo.AddOrder(orders);

                

                return CreatedAtAction(nameof(GetOrder), new { id = result.OrderId }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Customer record");
            }
        }

        
        // DELETE: api/Orders/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Orders>> DeleteOrders([FromRoute] int id)
        {
            try
            {
                var customerToDelete = await _orderepo.GetOrderByOrderId(id);
                if (customerToDelete == null)
                {
                    return NotFound($"Order with OrderId={id} not found in the records");

                }
                return await _orderepo.DeleteOrder(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleteing record");
            }
        }
    }
}