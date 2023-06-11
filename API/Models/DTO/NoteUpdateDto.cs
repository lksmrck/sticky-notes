using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models.DTO
{
    public class NoteUpdateDto
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
