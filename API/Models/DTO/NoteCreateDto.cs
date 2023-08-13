using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class NoteCreateDto
    {
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public string AuthorId { get; set; }
        public List<string> Tags { get; set; }
    }
}
