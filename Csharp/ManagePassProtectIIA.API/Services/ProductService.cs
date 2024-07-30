using ManagePassProtectIIA.API.Interfaces;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.Persistance;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagePassProtectIIA.API.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.Include(p => p.Type).ToListAsync();
        }

        public async Task<ActionResult<Product>> GetOneProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<ActionResult<Product>> PostOneProduct(Product product)
        {
            product.Created_at = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<ActionResult<Product>> PutOneProduct(int id, Product product)
        {
            product.Updated_at = DateTime.Now;

            try
            {
                if (id == product.Id)
                {
                    _context.Entry(product).State = EntityState.Modified;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return product;
        }

        public async Task<ActionResult<Product>> DeleteOneProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }
        public bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
