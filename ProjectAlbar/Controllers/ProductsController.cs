using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectAlbar.BL;
using ProjectAlbar.Models;

namespace ProjectAlbar.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductBL IproductBL;
        public ProductsController(IProductBL IproductBL
            )
        {
            this.IproductBL = IproductBL;
        }

        // GET: api/<productsController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            List<Product> products = await IproductBL.getAllProduct();
            if (products == null)
                return NoContent();
            return products;
        }

        // GET api/<productsController>/GetProductByCategory/5
        [HttpGet("GetProductByCategory/{Category}")]
        public async Task<ActionResult<List<Product>>> GetProductByCategory(string category)
        {
            var products = await IproductBL.getProductByCategory(category);
            if (products == null)
                return NoContent();
            return products;
        }


        // GET api/<productsController>/GetProductByName/5
        [HttpGet("GetProductByName/{ProductName}")]
        public async Task<ActionResult<List<Product>>> GetProductByName(string productName)
        {
            var products = await IproductBL.getProductByProductName(productName);
            if (products == null)
                return NoContent();
            return products;
        }

        // GET api/<productsController>/5
        [HttpGet("{Cost}")]
        public async Task<ActionResult<List<Product>>> Get(int cost)
        {
            var products = await IproductBL.getProductByPrice(cost);
            if (products == null)
                return NoContent();
            return products;
        }

        // POST api/<productsController>
        [HttpPost("CreateProduct")]
        public async Task<int> Post([FromBody] Product product)
        {
            int result = await IproductBL.postProduct(product);
            return result;
        }


        // PUT api/<productsController>/5
        [HttpPut("{id}")]
        public async Task<Product> Put([FromBody] Product value, int id)
        {
            await IproductBL.putProduct(value, id);
            return value;
        }

        // DELETE api/<productsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
