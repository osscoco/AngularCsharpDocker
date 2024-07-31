using ManagePassProtectIIA.API.Interfaces;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagePassProtectIIA.API.Services
{
    public class TypeService : ITypeService
    {
        private readonly AppDbContext _context;

        public TypeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<ResponseApi>> GetAllTypes()
        {
            var responseApi = new ResponseApi
            {
                Success = true,
                Data = await _context.Types.ToListAsync(),
                Message = "Liste de Types récupérée avec succès !"
            };

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> GetOneType(int id)
        {
            var responseApi = new ResponseApi
            {
                Success = true,
                Data = await _context.Types.FindAsync(id),
                Message = "Type récupéré avec succès !"
            };

            if (responseApi.Data == null)
            {
                responseApi.Success = false;
                responseApi.Data = null;
                responseApi.Message = "Type inexistant !";

                return responseApi;
            }

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> PostOneType(Models.Type type)
        {
            type.Created_at = DateTime.Now;
            _context.Types.Add(type);
            await _context.SaveChangesAsync();

            var responseApi = new ResponseApi
            {
                Success = true,
                Data = null,
                Message = "Type créé avec succès !"
            };

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> PutOneType(int id, Models.Type type)
        {
            type.Updated_at = DateTime.Now;

            var responseApi = new ResponseApi();

            try
            {
                if (id == type.Id)
                {
                    _context.Entry(type).State = EntityState.Modified;

                    await _context.SaveChangesAsync();

                    responseApi = new ResponseApi
                    {
                        Success = true,
                        Data = null,
                        Message = "Type modifié avec succès !"
                    };
                }
                else
                {
                    responseApi = new ResponseApi
                    {
                        Success = false,
                        Data = null,
                        Message = "Erreur de modification du Type !"
                    };
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
                {
                    responseApi = new ResponseApi
                    {
                        Success = false,
                        Data = null,
                        Message = "Erreur de modification du Type !"
                    };
                }
                else
                {
                    throw;
                }
            }

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> DeleteOneType(int id)
        {
            var type = await _context.Types.FindAsync(id);

            var responseApi = new ResponseApi();

            if (type == null)
            {
                responseApi = new ResponseApi
                {
                    Success = false,
                    Data = null,
                    Message = "Erreur de suppression du Type !"
                };
            }
            else
            {
                _context.Types.Remove(type);
                await _context.SaveChangesAsync();

                responseApi = new ResponseApi
                {
                    Success = true,
                    Data = null,
                    Message = "Type supprimé avec succès !"
                };
            }

            return responseApi;
        }

        public bool TypeExists(int id)
        {
            return _context.Types.Any(e => e.Id == id);
        }
    }
}
