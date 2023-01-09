using MovieService.ApiModel.Common;
using MovieService.ApiModel.Movies;
using MovieService.Model;
using MovieService.Service.Genres;
using MovieService.Service.Participants;
using MovieService.Service.Ratings;
using MovieService.Service.Reviews;
using MovieService.Service.Tags;
using System;

namespace MovieService.Service.Movies
{
    public static class MovieMapper
    {
        public static MovieDTO MapToDTO(Movie movie)
        {
            return new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = new DateDTO(movie.ReleaseDate.Year, movie.ReleaseDate.Month, movie.ReleaseDate.Day),
                DurationInMinutes = movie.DurationInMinutes,
                Cover = movie.Cover,
                BackgroundImage = movie.BackgroundImage,
                Thumbnail = movie.Thumbnail,
                Trailer = movie.Trailer
            };
        }

        public static MovieDetailsDTO MapToDetailsDTO(Movie movie)
        {
            return new MovieDetailsDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = new DateDTO(movie.ReleaseDate.Year, movie.ReleaseDate.Month, movie.ReleaseDate.Day),
                DurationInMinutes = movie.DurationInMinutes,
                Cover = movie.Cover,
                BackgroundImage = movie.BackgroundImage,
                Thumbnail = movie.Thumbnail,
                Trailer = movie.Trailer,
                AverageRating = movie.Rating.Average(rating => rating.Value),
                NumberOfRating = movie.Rating.Count,
                Reviews = movie.Reviews.Select(ReviewMapper.MapToDTO).ToList(),
                Genres = movie.Genres.Select(GenreMapper.MapToDTO).ToList(),
                Tags = movie.Tags.Select(TagMapper.MapToDTO).ToList(),
                Participants = movie.Participants.Select(ParticipantMapper.MapToDTO).ToList()
            };
        }

        public static Movie MapToEntity(MovieDTO movieDTO)
        {
            return new Movie
            {
                Id = movieDTO.Id,
                Title = movieDTO.Title,
                Description = movieDTO.Description,
                ReleaseDate = new DateTime(movieDTO.ReleaseDate.Year, movieDTO.ReleaseDate.Month, movieDTO.ReleaseDate.Day),
                DurationInMinutes = movieDTO.DurationInMinutes,
                Cover = movieDTO.Cover,
                BackgroundImage = movieDTO.BackgroundImage,
                Thumbnail = movieDTO.Thumbnail,
                Trailer = movieDTO.Trailer,
                Reviews = new List<Review>(),
                Rating = new List<Rating>(),
                Genres = new List<Genre>(),
                Tags = new List<Tag>(),
                Participants = new List<Participant>()
            };
        }
    }
}
