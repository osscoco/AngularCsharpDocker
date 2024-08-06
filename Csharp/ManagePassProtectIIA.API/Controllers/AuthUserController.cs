using Microsoft.AspNetCore.Mvc;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.API.Services;
using ManagePassProtectIIA.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace ManagePassProtectIIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly AuthUserService _authUserService;
        private readonly IConfiguration _configuration;

        public AuthUserController(IAuthUserService authUserService, IConfiguration configuration)
        {
            _authUserService = (AuthUserService)authUserService;
            _configuration = configuration;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<ResponseApi>> PostOneUser(User user)
        {
            return await _authUserService.PostOneUser(user);
        }

        //[AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ResponseApi>> Login([FromBody] LoginModel loginModel)
        {
            var responseApi = new ResponseApi();

            try
            {
                ArrayList arrayListResult = _authUserService.AuthenticateUserAsync(loginModel.Email, loginModel.Password);
            
                if (arrayListResult == null)
                {
                    return responseApi = new ResponseApi
                    {
                        Success = true,
                        Data = Unauthorized(),
                        Message = "Echec de l'authentification !"
                    };
                }
            
                return responseApi = new ResponseApi
                {
                    Success = true,
                    Data = Ok(new { User = arrayListResult[0], Token = arrayListResult[1] }),
                    Message = "Authentification réussi !"
                };
            }
            catch (Exception ex)
            {
                return new ResponseApi
                {
                    Success = false,
                    Data = StatusCode(500, new { error = ex.Message }),
                    Message = "Une erreur est survenue lors de l'authentification."
                };
            }

        }

        //[Authorize]
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            // Pour l'instant, cela peut juste retourner une réponse OK.
            // Invalider un JWT nécessite une implémentation plus avancée, comme la gestion d'une liste noire.
            return Ok(new { Message = "User logged out" });
        }
    }

    public class LoginModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
