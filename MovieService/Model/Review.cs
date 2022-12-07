using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Model
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("rating")]
        public int Rating { get; set; }

        [Column("content")]
        public string Content { get; set; } = null!;

        //public int 

        public ICollection<Comment> Comments { get; set; } = null!;
    }
}
