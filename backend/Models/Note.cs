using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Heading { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        //public List<Tag> Tags { get; set; }
        [NotMapped]
        public List<string> Tags { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
    }
}
