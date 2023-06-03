using backend.Data;
using backend.Models;
using backend.Repository.IRepository;

namespace backend.Repository
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        private readonly ApplicationDbContext _db;

        public NoteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Note> UpdateAsync(Note entity)
        {
            entity.EditedDate = DateTime.Now;
            _db.Notes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
