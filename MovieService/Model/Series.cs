﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Model
{
    public class Series
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; } = null!;

        [Column("description")]
        public string Description { get; set; } = null!;

        [Column("photo")]
        public string Photo { get; set; } = null!;

        [Column("trailer")]
        public string Trailer { get; set; } = null!;

        [Column("review_id")]
        public int ReviewId { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } = null!;

        public virtual ICollection<Genre> Genres { get; set; } = null!;

        public virtual ICollection<Tag> Tags { get; set; } = null!;

        public virtual ICollection<Episode> Episodes { get; set; } = null!;

        public virtual ICollection<Person> Persons { get; set; } = null!;
    }
}
