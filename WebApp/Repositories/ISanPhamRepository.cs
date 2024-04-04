using WebApp.Models;

namespace WebApp.Repositories
{
    public interface ISanPhamRepository
    {
        Task<IEnumerable<SanPham>> GetAllAsync();
        Task<SanPham> GetByIdAsync(int id);
        Task AddAsync(SanPham SanPham);
        Task UpdateAsync(SanPham SanPham);
        Task DeleteAsync(int id);
    }

}
