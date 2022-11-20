using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.Model
{
    [Table("movie", Schema = "dbo")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("description")]
        public String? Description { get; set; }

        [Column("releaseDate")]
        public DateTime? DateOfRelease { get; set; }

        [Column("duration")]
        public Duration? Duration { get; set; }

        [Column("genres")]
        public ICollection<Genre>? Genres { get; set; }

        //[Column("persons")]
        //public ICollection<Person>? Persons { get; set; }

        [Column("tags")]
        public ICollection<Tag>? Tags { get; set; }
    }
}