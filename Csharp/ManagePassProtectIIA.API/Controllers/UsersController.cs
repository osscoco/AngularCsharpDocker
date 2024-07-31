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
        public async Task<ActionResult<ResponseApi>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseApi>> GetOneUser(int id)
        {
            return await _userService.GetOneUser(id);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseApi>> PostOneUser(User user)
        {
            return await _userService.PostOneUser(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseApi>> PutOneUser(int id, User user)
        {
            return await _userService.PutOneUser(id, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseApi>> DeleteOneUser(int id)
        {
            return await _userService.DeleteOneUser(id);
        }
    }
}
