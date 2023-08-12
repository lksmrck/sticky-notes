using backend.Data;
using backend.Models;
using Domain.Note;

namespace API
{
    public class Seed
    {
        private readonly ApplicationDbContext _context;

        public Seed(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedDbContext()
        {
            if (!_context.Notes.Any())
            {
                //var notes = new List<Note>{
                //    new Note()
                //    {
                //        Id = 1,
                //        Heading = "First Note",
                //        Text = "Detailsaf nejfqo qnfwk qwfn qwf qn",
                //        Author = "Antonin Dvorak",
                //        //Tags = new List<Tag>() { new Tag() { Id = 1, Text = "firstTag", NoteId = 1 }, new Tag() { Id = 2, Text = "secondTag", NoteId = 1 } },
                //        //Tags = new List<string>() { "secondTag", "thirdTag" },
                //        Tags = new List<Tag>() { new Tag { /*NoteId = 1,*/ Text = "Tag1" }, new Tag { /*NoteId = 1,*/ Text = "Tag2" } },
                //        CreatedDate = DateTime.Now
                //    },
                //    new Note()
                //    {
                //        Id = 2,
                //        Heading = "Second Note",
                //        Text = "Detailsaf nejfqo qnfwk qwfn qwf qn",
                //        Author = "Bedrich Smetana",

                //        Tags = new List<Tag>() { new Tag {/* NoteId = 1,*/ Text = "eqgqegqeg" }, new Tag { /*NoteId = 2,*/ Text = "egqeg" } },
                //        CreatedDate = DateTime.Now
                //    }};

                var note1 = new Note()
                {

                    Heading = "First Note",
                    Text = "Detailsaf nejfqo qnfwk qwfn qwf qn",
                    Author = "Antonin Dvorak",
                    AuthorId = "600eeb4e-f98f-415d-a7e6-9ebbe3b39324",


                };


                var tags1 = new[] { "prvnitag", "druhytag" };


                note1.Tags.AddRange(tags1);

                _context.Notes.AddRange(note1);
                //_context.Notes.AddRange(notes);
                _context.SaveChanges();
            }
        }
    }
}
