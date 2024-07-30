using ManagePassProtectIIA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagePassProtectIIA.API.Interfaces
{
    public interface IUserService
    {
        public Task<ActionResult<ResponseApi>> GetAllUsers();
        public Task<ActionResult<ResponseApi>> GetOneUser(int id);
    }
}
