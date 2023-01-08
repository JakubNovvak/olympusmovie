﻿using MovieService.Model;
using MovieService.ApiModel;

namespace MovieService.Service
{
    public class SeriesMapper
    {
        public static SeriesDTO MapToDTO(Series series)
        {
            return new SeriesDTO
            {
                Id = series.Id,
                Title = series.Title,
                Description = series.Description,
                ReleaseDate = new DateDTO(series.ReleaseDate.Year, series.ReleaseDate.Month, series.ReleaseDate.Day),
                Cover = series.Cover,
                BackgroundImage = series.BackgroundImage,
                Thumbnail = series.Thumbnail,
                Trailer = series.Trailer
            };
        }

        public static SeriesDetailsDTO MapToDetailsDTO(Series series)
        {
            List<GenreDTO> genresDTO = new List<GenreDTO>();
            foreach(Genre genre in series.Genres)
            {
                genresDTO.Add(GenreMapper.MapToDTO(genre));
            }    

            List<TagDTO> tagsDTO = new List<TagDTO>();
            foreach (Tag tag in series.Tags)
            {
                tagsDTO.Add(TagMapper.MapToDTO(tag));
            }

            List<SeasonsDTO> seasonsDTO = new List<SeasonsDTO>();
            foreach (Season season in series.Seasons)
            {
                seasonsDTO.Add(SeasonMapper.MapToDTO(season));
            }

            List<PersonDTO> personsDTO = new List<PersonDTO>();
            foreach (Person person in series.Persons)
            {
                personsDTO.Add(PersonMapper.MapToDTO(person));
            }




            List<ReviewDTO> reviewsDTO = new List<ReviewDTO>();
            foreach (Review person in series.Reviews)
            {
                reviewsDTO.Add(ReviewMapper.MapToDTO(person));
            }

            List<SeasonsDTO> seasonDTO = new List<SeasonsDTO>();
            foreach (Season person in series.Seasons)
            {
                seasonDTO.Add(SeasonMapper.MapToDTO(person));
            }




            int RatingSum = 0;
            int NumberOfRating = 0;
            foreach (Rating rate in series.Rating)
            {
                NumberOfRating++;
                RatingSum += rate.value;
            }

            return new SeriesDetailsDTO
            {
                Id = series.Id,
                Title = series.Title,
                Description = series.Description,
                ReleaseDate = new DateDTO(series.ReleaseDate.Year, series.ReleaseDate.Month, series.ReleaseDate.Day),
                Cover = series.Cover,
                BackgroundImage = series.BackgroundImage,
                Thumbnail = series.Thumbnail,
                Trailer = series.Trailer,
                AverageRating = Math.Round((double)RatingSum / (double)NumberOfRating, 2),
                NumberOfRating = NumberOfRating,
                Reviews = reviewsDTO,
                Genres = genresDTO,
                Tags = tagsDTO,
                Seasons = seasonDTO,
                Persons = personsDTO
            };
        }

        public static Series MapToEntity(SeriesDTO seriesDTO)
        {
            return new Series
            {
                Id = seriesDTO.Id,
                Title = seriesDTO.Title,
                Description = seriesDTO.Description,
                ReleaseDate = new DateTime(seriesDTO.ReleaseDate.Year, seriesDTO.ReleaseDate.Month, seriesDTO.ReleaseDate.Day),
                Cover = seriesDTO.Cover,
                BackgroundImage = seriesDTO.BackgroundImage,
                Thumbnail = seriesDTO.Thumbnail,
                Trailer = seriesDTO.Trailer,
                Reviews = new List<Review>(),
                Rating = new List<Rating>(),
                Genres = new List<Genre>(),
                Tags = new List<Tag>(),
                Seasons = new List<Season>(),
                Persons = new List<Person>()
            };
        }
    }
}
