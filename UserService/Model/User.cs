using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace UserService.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("surname")]
        public string Surname { get; set; } = null!;

        [Column("user_name")]
        public string UserName { get; set; } = null!;

        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("photo")]
        public string Photo { get; set; } = null!;

        //[Column("watchig_movies")]
        //public ICollection<int> WatchingMovies { get; set; } = null!;

        //[Column("completed_movies")]
        //public ICollection<int> CompletedMovies { get; set; } = null!;

        //[Column("on_hold_movies")]
        //public ICollection<int> OnHoldMovies { get; set; } = null!;

        //[Column("dropped_movies")]
        //public ICollection<int> DroppedMovies { get; set; } = null!;

        //[Column("plan_to_watch_movies")]
        //public ICollection<int> PlanToWatchMovies { get; set; } = null!;

        //[Column("watchig")]
        //public ICollection<int> WatchingSeries { get; set; } = null!;

        //[Column("completed")]
        //public ICollection<int> CompletedSeries { get; set; } = null!;

        //[Column("on_hold")]
        //public ICollection<int> OnHoldSeries { get; set; } = null!;

        //[Column("dropped")]
        //public ICollection<int> DroppedSeries { get; set; } = null!;

        //[Column("plan_to_watch")]
        //public ICollection<int> PlanToWatchSeries { get; set; } = null!;
    }
}
