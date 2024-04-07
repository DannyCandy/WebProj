using WebApp.Models;

namespace WebApp.Repositories
{
    public interface INhaPhanPhoiRepository
    {
        Task<IEnumerable<NhaPhanPhoi>> GetAllAsync();
        Task<NhaPhanPhoi> GetByIdAsync(string id);
        Task AddAsync(NhaPhanPhoi nhaPhanPhoi);
        Task UpdateAsync(NhaPhanPhoi nhaPhanPhoi);
        Task DeleteAsync(string id);
    }
}
