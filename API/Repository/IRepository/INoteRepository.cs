using backend.Models;

namespace backend.Repository.IRepository
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<Note> UpdateAsync(Note entity);
    }
}
