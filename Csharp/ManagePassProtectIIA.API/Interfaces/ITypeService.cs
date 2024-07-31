using ManagePassProtectIIA.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagePassProtectIIA.API.Interfaces
{
    public interface ITypeService
    {
        public Task<ActionResult<ResponseApi>> GetAllTypes();
        public Task<ActionResult<ResponseApi>> GetOneType(int id);
        public Task<ActionResult<ResponseApi>> PostOneType(Models.Type type);
        public Task<ActionResult<ResponseApi>> PutOneType(int id, Models.Type type);
        public Task<ActionResult<ResponseApi>> DeleteOneType(int id);
        public bool TypeExists(int id);
    }
}
