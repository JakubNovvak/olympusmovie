using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Model
{
    [Table("series", Schema = "dbo")]
    public class Series
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        [Column("genres")]
        public ICollection<Genre>? Genres { get; set; }

        //[Column("persons")]
        //public ICollection<Person>? Persons { get; set; }

        [Column("tags")]
        public ICollection<Tag>? Tags { get; set; }
    }
}
