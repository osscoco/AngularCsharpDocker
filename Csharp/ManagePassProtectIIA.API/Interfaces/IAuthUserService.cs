using ManagePassProtectIIA.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ManagePassProtectIIA.API.Interfaces
{
    public interface IAuthUserService
    {
        public ArrayList AuthenticateUserAsync(string email, string password);
        public Task<ActionResult<ResponseApi>> PostOneUser(User user);
        public bool UserExists(int id);
    }
}
