using WebApp.Models;

namespace WebApp.Repositories
{
    public interface ISanPhamRepository
    {
        Task<IEnumerable<SanPham>> GetAllAsync();
        Task<SanPham> GetByIdAsync(string id);
        Task AddAsync(SanPham SanPham);
        Task UpdateAsync(SanPham SanPham);
        Task DeleteAsync(string id);
    }

}
