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
                Message = "Liste d'utilisateurs récupérée avec succès !"
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
    }
}
