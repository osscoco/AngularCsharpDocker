using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ManagePassProtectIIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwaggerController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("swagger")]
        public IActionResult GetSwagger()
        {
            return Redirect("~/swagger/index.html");
        }
    }
}
