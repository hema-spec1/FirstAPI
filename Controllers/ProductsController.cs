using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstAPI.Data;
using FirstAPI.Model;
using FirstAPI.Provider;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProvider _prod;

        public ProductsController(IProvider prod)
        {
            _prod = prod;
        }

        // GET: api/Products
        [HttpGet]
        public List<Product> GetProduct()
        {
            //public await Task.FromResult(_prod.GetProduct());
            return _prod.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {

            return _prod.GetProductById(id);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {

            try
            {
                _prod.UpdateProduct(id, product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_prod.ProductExists(id))
                {
                    return NotFound();
                }

            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _prod.AddNewProduct(product);
            return CreatedAtAction("GetProduct", new { id = product.PrId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _prod.DeleteProduct(id);
            
            return NoContent();
        }
        [Route("[action]/{id}/{qty}")]
        [HttpGet]
        public bool chy(int id, int qty)
        {
            return _prod.checkquality(id, qty);

        }


    }
}
