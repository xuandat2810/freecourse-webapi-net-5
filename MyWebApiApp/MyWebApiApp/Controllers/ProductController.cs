using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll ()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                //LINQ [Object] Query
                var product = products.SingleOrDefault(p => p.IDProduct == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductVM productVM)
        {
            Product product = new Product
            {
                IDProduct = Guid.NewGuid(),
                NameProduct = productVM.NameProduct,
                Amount = productVM.Amount
            };
            products.Add(product);
            return Ok(new {
                Success = true, Data = products
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(string id, Product productEdit)
        {
            try
            {
                //LINQ [Object] Query
                var product = products.SingleOrDefault(p => p.IDProduct == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                if (Guid.Parse(id) != productEdit.IDProduct)
                {
                    return BadRequest();
                } 
                //Update
                product.NameProduct = productEdit.NameProduct;
                product.Amount = productEdit.Amount;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("id")]
        public IActionResult DeleteProduct(string id)
        {
            try
            {
                //LINQ [Object] Query
                var product = products.SingleOrDefault(p => p.IDProduct == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                //Update
                products.Remove(product);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
