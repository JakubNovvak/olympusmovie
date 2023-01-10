using MovieService.ApiModel.Common;
using MovieService.ApiModel.Episodes;
using MovieService.ApiModel.Genres;
using MovieService.ApiModel.Participants;
using MovieService.ApiModel.Reviews;
using MovieService.ApiModel.Tags;
using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel.Seasons
{
    public class SeasonDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Number { get; set; }
        public string Description { get; set; } = null!;
        public virtual DateDTO ReleaseDate { get; set; } = null!;
        public string Cover { get; set; } = null!;
        public string BackgroundImage { get; set; } = null!;
        public string Thumbnail { get; set; } = null!;
        public string Trailer { get; set; } = null!;
        public double? AverageRating { get; set; }
        public int NumberOfRating { get; set; }
        public ICollection<EpisodeDTO> Episodes { get; set; } = null!;
        public ICollection<ReviewDTO> Reviews { get; set; } = null!;
        public ICollection<GenreDTO> Genres { get; set; } = null!;
        public ICollection<TagDTO> Tags { get; set; } = null!;
        public ICollection<ParticipantDTO> Participants { get; set; } = null!;
    }
}
