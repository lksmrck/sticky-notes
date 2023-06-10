using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Note")]
        public int NoteId { get; set; }
        public string Text { get; set; }
    }
}
