using ManagePassProtectIIA.API.Interfaces;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.Persistance;
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

        public async Task<ActionResult<ResponseApi>> GetAllProducts()
        {
            var responseApi = new ResponseApi
            {
                Success = true,
                Data = await _context.Products.Include(p => p.Type).ToListAsync(),
                Message = "Liste de Produits récupérée avec succès !"
            };

            return responseApi; 
        }

        public async Task<ActionResult<ResponseApi>> GetOneProduct(int id)
        {
            var responseApi = new ResponseApi
            {
                Success = true,
                Data = await _context.Products.FindAsync(id),
                Message = "Produit récupéré avec succès !"
            };

            if (responseApi.Data == null)
            {
                responseApi.Success = false;
                responseApi.Data = null;
                responseApi.Message = "Produit inexistant !";

                return responseApi;
            }

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> PostOneProduct(Product product)
        {
            var type = await _context.Types.FindAsync(product.TypeId);

            if (type == null)
            {
                return new ResponseApi
                {
                    Success = false,
                    Data = null,
                    Message = "Type Inexistant !"
                };
            }

            product.Created_at = DateTime.Now;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var responseApi = new ResponseApi
            {
                Success = true,
                Data = null,
                Message = "Produit créé avec succès !"
            };

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> PutOneProduct(int id, Product product)
        {
            product.Updated_at = DateTime.Now;

            var responseApi = new ResponseApi();

            try
            {
                if (id == product.Id)
                {
                    _context.Entry(product).State = EntityState.Modified;

                    await _context.SaveChangesAsync();

                    responseApi = new ResponseApi
                    {
                        Success = true,
                        Data = null,
                        Message = "Produit modifié avec succès !"
                    };
                }
                else
                {
                    responseApi = new ResponseApi
                    {
                        Success = false,
                        Data = null,
                        Message = "Erreur de modification du Produit !"
                    };
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    responseApi = new ResponseApi
                    {
                        Success = false,
                        Data = null,
                        Message = "Erreur de modification du Produit !"
                    };
                }
                else
                {
                    throw;
                }
            }

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> DeleteOneProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            var responseApi = new ResponseApi();

            if (product == null)
            {
                responseApi = new ResponseApi
                {
                    Success = false,
                    Data = null,
                    Message = "Erreur de suppression du Produit !"
                };
            }
            else
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                responseApi = new ResponseApi
                {
                    Success = true,
                    Data = null,
                    Message = "Produit supprimé avec succès !"
                };
            }

            return responseApi;
        }

        public bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
