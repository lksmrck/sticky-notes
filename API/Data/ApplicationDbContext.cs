using AutoMapper.Execution;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
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
            modelBuilder.Entity<Note>()
               .Property(x => x.Tags)
               .HasConversion(new ValueConverter<List<string>, string>(
               v => JsonConvert.SerializeObject(v), // Convert to string for persistence
               v => JsonConvert.DeserializeObject<List<string>>(v)));

        }
    }

   
}
