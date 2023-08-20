

using Domain.Note;
using Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;


namespace Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        // Create tables
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Note> Notes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>()
               .Property(x => x.Tags)
               .HasConversion(new ValueConverter<List<string>, string>(
               v => JsonConvert.SerializeObject(v), // Convert to string for persistence
               v => JsonConvert.DeserializeObject<List<string>>(v)));

        }
    }


}
