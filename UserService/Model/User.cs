using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using UserService.Model.Relations;

namespace UserService.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("UserName")]
        public string UserName { get; set; } = null!;

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("surname")]
        public string Surname { get; set; } = null!;

        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("photo")]
        public string? Photo { get; set; }
        [Column("background_photo")]
        public string? BackgroundPhoto { get; set; }

        [Column("join_date")]
        public DateTime JoinDate { get; set; }

        public virtual ICollection<UserRelationToPosition> UserRelationsToPositions { get; set; } = null!;
        public virtual ICollection<UserWatchedEpisodesCount> UserWatchedEpisodesCounts { get; set; } = null!;
    }
}
