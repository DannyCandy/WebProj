using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repositories
{
    public class EFNhaPhanPhoiRepository : INhaPhanPhoiRepository
    {
        private readonly AgriculturalProductsContext _context;
        public EFNhaPhanPhoiRepository(AgriculturalProductsContext context)
        {
            _context = context;
        }
        public async Task AddAsync(NhaPhanPhoi nhaPhanPhoi)
        {
            _context.NhaPhanPhois.Add(nhaPhanPhoi);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var nhaPhanPhoi = await _context.NhaPhanPhois.FindAsync(id);
            _context.NhaPhanPhois.Remove(nhaPhanPhoi);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NhaPhanPhoi>> GetAllAsync()
        {
            return await _context.NhaPhanPhois.ToListAsync();
        }

        public async Task<NhaPhanPhoi> GetByIdAsync(string id)
        {
            return await _context.NhaPhanPhois.FindAsync(id);
        }

        public async Task UpdateAsync(NhaPhanPhoi nhaPhanPhoi)
        {
            _context.NhaPhanPhois.Update(nhaPhanPhoi);
            await _context.SaveChangesAsync();
        }
    }
}
