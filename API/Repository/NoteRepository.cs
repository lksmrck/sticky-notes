using backend.Data;
using backend.Models;
using backend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        private readonly ApplicationDbContext _db;

        public NoteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task CreateAsync(Note entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _db.Notes.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<Note> UpdateAsync(Note entity)
        {

            Note note = await _db.Notes.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            entity.CreatedDate = note.CreatedDate;
            entity.EditedDate = DateTime.Now;

            // EF Core už trackuje entitu, kvůli řádkům výše (přidání původního CreatedDate). Aby šlo update, tak detachnu trackování a pak updatnu.
            _db.Entry(note).State = EntityState.Detached;

            _db.Notes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
