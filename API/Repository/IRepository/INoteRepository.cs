using backend.Models;
using Domain.Note;

namespace backend.Repository.IRepository
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<Note> UpdateAsync(Note entity);
    }
}
