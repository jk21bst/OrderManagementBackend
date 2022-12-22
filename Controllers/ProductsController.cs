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
    public class ProductsController : ControllerBase
    {

        private readonly IProducts _productrepo;

        public ProductsController(IProducts productrepo)
        { 

            _productrepo = productrepo;

        }

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            try
            {
                return Ok(await _productrepo.GetProducts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrievind data from database");
            }
        }


        // GET: api/Items/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Products>> GetProduct([FromRoute] int id)
        {
            try
            {
                var result = await _productrepo.GetProductByProductId(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrievind data from database");
            }
        }


        // PUT: api/Items/5
        [HttpPut("update/{id}")]
        public async Task<ActionResult<Products>> PutProducts([FromRoute] int id, [FromBody] Products products)
        {
            try
            {
                if (id != products.ProductId)
                {
                    return BadRequest($"Customer with Id={id} not found");
                }
                var updateItem = await _productrepo.GetProductByProductId(id);
                if (updateItem == null)
                {
                    return NotFound($"Employee with Id={id} not found");
                }
                return await _productrepo.UpdateProduct(products);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating record");
            }
        }

        // POST: api/Items
        [HttpPost("add")]
        public async Task<ActionResult<Products>> PostProducts([FromBody] Products products)
        {
            try
            {
                if (products == null)
                {
                    return BadRequest();
                }
                var result = await _productrepo.AddProduct(products);
                return CreatedAtAction(nameof(GetProduct), new { id = products.ProductId }, products);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Attempt failed to add item into Item");
            }




        }

        // DELETE: api/Items/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Products>> DeleteProduct([FromRoute] int id)
        {
            try
            {
                var result = await _productrepo.GetProductByProductId(id);
                if (result == null)
                {
                    return BadRequest($"Failed to delete the item with Id={id} ");
                }
                return await _productrepo.DeleteProduct(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleteing the item from the database");
            }


        }

    }
}