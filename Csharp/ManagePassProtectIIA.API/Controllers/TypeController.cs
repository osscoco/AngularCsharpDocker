using Microsoft.AspNetCore.Mvc;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.API.Services;
using ManagePassProtectIIA.API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace ManagePassProtectIIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly TypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = (TypeService)typeService;
        }

        // GET: api/Types
        [HttpGet]
        public async Task<ActionResult<ResponseApi>> GetAllTypes()
        {
            return await _typeService.GetAllTypes();
        }

        // GET: api/Types/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseApi>> GetOneType(int id)
        {
            return await _typeService.GetOneType(id);
        }

        // POST: api/Type
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseApi>> PostOneType(Models.Type type)
        {
            return await _typeService.PostOneType(type);
        }

        // PUT: api/Type/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseApi>> PutOneType(int id, Models.Type type)
        {
            return await _typeService.PutOneType(id, type);
        }

        // DELETE: api/Type/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseApi>> DeleteOneType(int id)
        {
            return await _typeService.DeleteOneType(id);
        }
    }
}
