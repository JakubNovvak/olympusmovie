using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Model
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("surname")]
        public string Surname { get; set; } = null!;

        [Column("birthdate")]
        public DateTime Birthdate { get; set; }

        [Column("photo")]
        public string Photo { get; set; } = null!;

        public virtual ICollection<ParticipantMovie> MovieParticipants { get; set; } = null!;
        public virtual ICollection<ParticipantSeason> SeasonParticipants { get; set; } = null!;
    }
}
