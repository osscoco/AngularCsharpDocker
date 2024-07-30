using Microsoft.AspNetCore.Mvc;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.API.Services;
using ManagePassProtectIIA.API.Interfaces;

namespace ManagePassProtectIIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = (UserService)userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<ResponseApi>> GetUsers()
        {
            return await _userService.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseApi>> GetUser(int id)
        {
            return await _userService.GetOneUser(id);
        }
    }
}
