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
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItems _ordritrepo;

        public OrderItemsController(IOrderItems ordritrepo)
        {
            _ordritrepo = ordritrepo;

        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItems>>> GetOrderItems()
        {
            try
            {
                return Ok(await _ordritrepo.GetOrderItems());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No Records in the database");
            }
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItems>> GetOrderItems([FromRoute] int id)
        {
            try
            {
                var result = await _ordritrepo.GetOrderItemByOrderProductId(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No Records in the database");
            }
        }
        [HttpGet("orderId/{orderId}")]

        public ActionResult<IEnumerable<OrderItems>> GetTempItemByOrderd([FromRoute] int orderId)
        {
            try
            {
                List<OrderItems> result = _ordritrepo.GetOrderItemsByOrderId(orderId);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No Records in the database");
            }
        }
        // PUT: api/OrderItems/5
        [HttpPut("update/{id}")]
        public async Task<ActionResult<OrderItems>> PutOrderItems([FromRoute] int id, [FromBody] OrderItems orderItems)
        {
            try
            {
                if (id != orderItems.OrderProductId)
                {
                    return BadRequest($"Order with Id={id} not found");
                }
                var updateOrder = await _ordritrepo.GetOrderItemByOrderProductId(id);
                if (updateOrder == null)
                {
                    return NotFound($"Order with Id={id} not found");
                }
                return await _ordritrepo.UpdateOrderItems(orderItems);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating record");
            }
        }

        // POST: api/OrderItems
        [HttpPost("add")]
        public async Task<ActionResult<OrderItems>> PostOrderItems([FromBody] OrderItems orderItems)
        {
            try
            {
                if (orderItems == null)
                {
                    return BadRequest();
                }
                var result = await _ordritrepo.AddOrderItems(orderItems);

                return CreatedAtAction(nameof(GetOrderItems), new { id = result.OrderProductId }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new order item record");
            }
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<OrderItems>> DeleteOrderItems([FromRoute] int id)
        {
            try
            {
                var result = await _ordritrepo.GetOrderItemByOrderProductId(id);
                if (result == null)
                {
                    return NotFound($"Order with FoodId={id} not found in the records");

                }
                return await _ordritrepo.DeleteOrderItems(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleteing record");
            }
        }
    }
}