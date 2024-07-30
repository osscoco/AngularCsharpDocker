using ManagePassProtectIIA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ManagePassProtectIIA.API.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<ActionResult<Product>> GetOneProduct(int id);
        public Task<ActionResult<Product>> PostOneProduct(Product product);
        public Task<ActionResult<Product>> PutOneProduct(int id, Product product);
        public Task<ActionResult<Product>> DeleteOneProduct(int id);
        public bool ProductExists(int id);
    }
}
