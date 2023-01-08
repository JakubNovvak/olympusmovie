using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.Model
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("value")]
        public int value { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("position_id")]
        public int PositionId { get; set; }

        [Column("position_type")]
        public string PositionType { get; set; } = null!;
    }
}
