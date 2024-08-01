using Microsoft.AspNetCore.Mvc;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.API.Services;
using ManagePassProtectIIA.API.Interfaces;

namespace ManagePassProtectIIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwaggerController : ControllerBase
    {
        [HttpGet]
        [Route("swagger")]
        public IActionResult GetSwagger()
        {
            return Redirect("~/swagger/index.html");
        }
    }
}
