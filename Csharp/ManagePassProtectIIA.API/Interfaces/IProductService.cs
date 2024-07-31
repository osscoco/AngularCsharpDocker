using ManagePassProtectIIA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagePassProtectIIA.API.Interfaces
{
    public interface IProductService
    {
        public Task<ActionResult<ResponseApi>> GetAllProducts();
        public Task<ActionResult<ResponseApi>> GetOneProduct(int id);
        public Task<ActionResult<ResponseApi>> PostOneProduct(Product product);
        public Task<ActionResult<ResponseApi>> PutOneProduct(int id, Product product);
        public Task<ActionResult<ResponseApi>> DeleteOneProduct(int id);
        public bool ProductExists(int id);
    }
}
