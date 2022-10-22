using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.Entities
{
    [Table("movie", Schema = "dbo")]
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("date_of_release")]
        public DateTime? DateOfRelease { get; set; }

        [Column("description")]
        public String? Description { get; set; }
    }
}