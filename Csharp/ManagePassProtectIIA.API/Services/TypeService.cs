using ManagePassProtectIIA.API.Interfaces;
using ManagePassProtectIIA.Models;
using ManagePassProtectIIA.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManagePassProtectIIA.API.Services
{
    public class TypeService : ITypeService
    {
        private readonly AppDbContext _context;
        public TypeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Models.Type>> GetAllTypes()
        {
            return await _context.Types.ToListAsync();
        }

        public async Task<ActionResult<Models.Type>> GetOneType(int id)
        {
            var type = await _context.Types.FindAsync(id);

            if (type == null)
            {
                return null;
            }

            return type;
        }

        public async Task<ActionResult<Models.Type>> PostOneType(Models.Type type)
        {
            type.Created_at = DateTime.Now;
            _context.Types.Add(type);
            await _context.SaveChangesAsync();

            return type;
        }

        public async Task<ActionResult<Models.Type>> PutOneType(int id, Models.Type type)
        {
            type.Updated_at = DateTime.Now;

            try
            {
                if (id == type.Id)
                {
                    _context.Entry(type).State = EntityState.Modified;

                    await _context.SaveChangesAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return type;
        }

        public async Task<ActionResult<Models.Type>> DeleteOneType(int id)
        {
            var type = await _context.Types.FindAsync(id);

            if (type == null)
            {
                return null;
            }

            _context.Types.Remove(type);
            await _context.SaveChangesAsync();

            return type;
        }
        public bool TypeExists(int id)
        {
            return _context.Types.Any(e => e.Id == id);
        }
    }
}
