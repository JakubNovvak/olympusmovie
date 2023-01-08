using MovieService.ApiModel;
using MovieService.Model;
using System;

namespace MovieService.Service
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
            List<ReviewDTO> reviewsDTO = new List<ReviewDTO>();
            foreach (Review review in movie.Reviews)
            {
                reviewsDTO.Add(ReviewMapper.MapToDTO(review));
            }

            List<RatingDTO> ratingsDTO = new List<RatingDTO>();
            foreach (Rating rating in movie.Rating)
            {
                ratingsDTO.Add(RatingMapper.MapToDTO(rating));
            }

            List<GenreDTO> genresDTO = new List<GenreDTO>();
            foreach (Genre genre in movie.Genres)
            {
                genresDTO.Add(GenreMapper.MapToDTO(genre));
            }

            List<TagDTO> tagsDTO = new List<TagDTO>();
            foreach (Tag tag in movie.Tags)
            {
                tagsDTO.Add(TagMapper.MapToDTO(tag));
            }

            List<PersonDTO> personsDTO = new List<PersonDTO>();
            foreach (Person person in movie.Persons)
            {
                personsDTO.Add(PersonMapper.MapToDTO(person));
            }

            int RatingSum = 0;
            int NumberOfRating = 0;
            foreach (Rating rate in movie.Rating)
            {
                NumberOfRating++;
                RatingSum += rate.value;
            }

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
                AverageRating = Math.Round( (double)RatingSum / (double)NumberOfRating,2),
                NumberOfRating = NumberOfRating,
                Reviews = reviewsDTO,
                Genres = genresDTO,
                Tags = tagsDTO,
                Persons = personsDTO
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
                Persons = new List<Person>()
            };
        }
    }
}
