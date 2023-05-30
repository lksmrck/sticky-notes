using backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        // Create tables
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(
                new Note()
                {
                    Id = 1,
                    Heading = "First Note",
                    Text = "Detailsaf nejfqo qnfwk qwfn qwf qn",
                    Author = "Antonin Dvorak",
                    //Tags = new List<Tag>() { new Tag() { Id = 1, Text = "firstTag", NoteId = 1 }, new Tag() { Id = 2, Text = "secondTag", NoteId = 1 } },
                    Tags = new List<string>() { "secondTag", "thirdTag" },
                    CreatedDate = DateTime.Now
                },
                new Note()
                {
                    Id = 2,
                    Heading = "Second Note",
                    Text = "Detailsaf nejfqo qnfwk qwfn qwf qn",
                    Author = "Bedrich Smetana",
                    //Tags = new List<Tag>() { new Tag() { Id = 3, Text = "thirdTag", NoteId = 2 }, new Tag() { Id = 4, Text = "fourthTag", NoteId = 2 } },
                    Tags = new List<string>() { "firstTag", "sixtsTag"},
                    CreatedDate = DateTime.Now
                }

                );

        }
    }

   
}
