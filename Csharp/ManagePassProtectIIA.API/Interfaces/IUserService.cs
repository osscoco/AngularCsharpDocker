using ManagePassProtectIIA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagePassProtectIIA.API.Interfaces
{
    public interface IUserService
    {
        public Task<ActionResult<ResponseApi>> GetAllUsers();
        public Task<ActionResult<ResponseApi>> GetOneUser(int id);
        public Task<ActionResult<ResponseApi>> PostOneUser(User user);
        public Task<ActionResult<ResponseApi>> PutOneUser(int id, User user);
        public Task<ActionResult<ResponseApi>> DeleteOneUser(int id);
        public bool UserExists(int id);
    }
}
