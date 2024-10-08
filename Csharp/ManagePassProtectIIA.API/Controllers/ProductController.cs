﻿using Microsoft.AspNetCore.Mvc;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.API.Services;
using ManagePassProtectIIA.API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ManagePassProtectIIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = (ProductService)productService;
        }

        // GET: api/Products
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<ResponseApi>> GetAllProducts()
        {
            return await _productService.GetAllProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseApi>> GetOneProduct(int id)
        {
            return await _productService.GetOneProduct(id);
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("new")]
        public async Task<ActionResult<ResponseApi>> PostOneProduct(Product product)
        {
            return await _productService.PostOneProduct(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseApi>> PutOneProduct(int id, Product product)
        {
            return await _productService.PutOneProduct(id, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseApi>> DeleteOneProduct(int id)
        {
            return await _productService.DeleteOneProduct(id);
        }
    }
}
