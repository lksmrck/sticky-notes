using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.DTO
{
    public class NoteDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Heading { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Author { get; set; }
   
        public List<string> Tags { get; set; } 
    }
}
