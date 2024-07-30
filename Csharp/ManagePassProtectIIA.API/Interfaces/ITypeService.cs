using ManagePassProtectIIA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagePassProtectIIA.API.Interfaces
{
    public interface ITypeService
    {
        public Task<IEnumerable<Models.Type>> GetAllTypes();
        public Task<ActionResult<Models.Type>> GetOneType(int id);
        public Task<ActionResult<Models.Type>> PostOneType(Models.Type type);
        public Task<ActionResult<Models.Type>> PutOneType(int id, Models.Type type);
        public Task<ActionResult<Models.Type>> DeleteOneType(int id);
        public bool TypeExists(int id);
    }
}
