using ManagePassProtectIIA.API.Interfaces;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagePassProtectIIA.API.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<ResponseApi>> GetAllUsers()
        {
            var responseApi = new ResponseApi
            {
                Success = true,
                Data = await _context.Users.ToListAsync(),
                Message = "Liste d'Utilisateurs récupérée avec succès !"
            };

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> GetOneUser(int id)
        {
            var responseApi = new ResponseApi
            {
                Success = true,
                Data = await _context.Users.FindAsync(id),
                Message = "Utilisateur récupéré avec succès !"
            };

            if (responseApi.Data == null)
            {
                responseApi.Success = false;
                responseApi.Data = null;
                responseApi.Message = "Utilisateur inexistant !";

                return responseApi;
            }

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> PostOneUser(User user)
        {
            user.Created_at = DateTime.Now;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var responseApi = new ResponseApi
            {
                Success = true,
                Data = null,
                Message = "Utilisateur créé avec succès !"
            };

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> PutOneUser(int id, User user)
        {
            user.Updated_at = DateTime.Now;

            var responseApi = new ResponseApi();

            try
            {
                if (id == user.Id)
                {
                    _context.Entry(user).State = EntityState.Modified;

                    await _context.SaveChangesAsync();

                    responseApi = new ResponseApi
                    {
                        Success = true,
                        Data = null,
                        Message = "Utilisateur modifié avec succès !"
                    };
                }
                else
                {
                    responseApi = new ResponseApi
                    {
                        Success = false,
                        Data = null,
                        Message = "Erreur de modification de l'Utilisateur !"
                    };
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    responseApi = new ResponseApi
                    {
                        Success = false,
                        Data = null,
                        Message = "Erreur de modification de l'Utilisateur !"
                    };
                }
                else
                {
                    throw;
                }
            }

            return responseApi;
        }

        public async Task<ActionResult<ResponseApi>> DeleteOneUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            var responseApi = new ResponseApi();

            if (user == null)
            {
                responseApi = new ResponseApi
                {
                    Success = false,
                    Data = null,
                    Message = "Erreur de suppression de l'Utilisateur !"
                };
            }
            else
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                responseApi = new ResponseApi
                {
                    Success = true,
                    Data = null,
                    Message = "Utilisateur supprimé avec succès !"
                };
            }

            return responseApi;
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
