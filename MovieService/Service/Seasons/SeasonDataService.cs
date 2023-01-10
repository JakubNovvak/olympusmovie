using MovieService.ApiModel.Movies;
using MovieService.ApiModel.Seasons;
using MovieService.Model;
using MovieService.Repository;
using MovieService.Service.Movies;
using MovieService.Service.Participants;

namespace MovieService.Service.Seasons
{
    public class SeasonDataService : ISeasonDataService
    {
        private readonly MovieDbContext _dbContext;

        public SeasonDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(SeasonCreateEditDTO seasonDTO)
        {
            var season = new Season()
            {
                Title = seasonDTO.Title,
                Description = seasonDTO.Description,
                ReleaseDate = new DateTime(seasonDTO.ReleaseDate.Year, seasonDTO.ReleaseDate.Month, seasonDTO.ReleaseDate.Day),
                Cover = seasonDTO.Cover,
                BackgroundImage = seasonDTO.BackgroundImage,
                Thumbnail = seasonDTO.Thumbnail,
                Trailer = seasonDTO.Trailer,
                Tags = _dbContext.Set<Tag>().Where(tag => seasonDTO.TagIds.Contains(tag.Id)).ToList(),
                Genres = _dbContext.Set<Genre>().Where(genre => seasonDTO.GenreIds.Contains(genre.Id)).ToList(),
            };
            var createdSeason = await _dbContext.Set<Season>().AddAsync(season);
            
            if (createdSeason == null)
            {
                return 0;
            }

            await _dbContext.SaveChangesAsync();
            SyncSeasonParticipantsWithoutSave(seasonDTO, createdSeason.Entity.Id);
            await _dbContext.SaveChangesAsync();
            return createdSeason.Entity.Id;
        }

        public async Task<int> EditAsync(SeasonCreateEditDTO seasonDTO)
        {
            var seasonToEdit = await _dbContext.Set<Season>().FindAsync(seasonDTO.Id);
            
            if (seasonToEdit == null)
            {
                return 0;
            }

            seasonToEdit.Title = seasonDTO.Title;
            seasonToEdit.Description = seasonDTO.Description;
            seasonToEdit.ReleaseDate = new DateTime(seasonDTO.ReleaseDate.Year, seasonDTO.ReleaseDate.Month, seasonDTO.ReleaseDate.Day);
            seasonToEdit.Cover = seasonDTO.Cover;
            seasonToEdit.BackgroundImage = seasonDTO.BackgroundImage;
            seasonToEdit.Thumbnail = seasonDTO.Thumbnail;
            seasonToEdit.Trailer = seasonDTO.Trailer;
            seasonToEdit.Tags = _dbContext.Set<Tag>().Where(tag => seasonDTO.TagIds.Contains(tag.Id)).ToList();
            seasonToEdit.Genres = _dbContext.Set<Genre>().Where(genre => seasonDTO.GenreIds.Contains(genre.Id)).ToList();
            SyncSeasonParticipantsWithoutSave(seasonDTO, seasonToEdit.Id);
            await _dbContext.SaveChangesAsync();

            return seasonToEdit.Id;
        }

        private void SyncSeasonParticipantsWithoutSave(SeasonCreateEditDTO seasonDTO, int seasonId)
        {
            var currentSeasonParticipants = _dbContext.Set<ParticipantSeason>()
                .Where(participantSeason => participantSeason.SeasonId == seasonId).ToList();
            _dbContext.Set<ParticipantSeason>().RemoveRange(currentSeasonParticipants);
            _dbContext.Set<ParticipantSeason>().AddRange(seasonDTO.Participants.Select(participant => ParticipantMapper.MapToEntity(participant, seasonId)));
        }

        public IEnumerable<SeasonDTO> GetAll()
        {
            return _dbContext.Seasons.Select(season => SeasonMapper.MapToDTO(season));
        }

        public async Task<SeasonDetailsDTO?> GetById(int id)
        {
            var season = await _dbContext.Set<Season>().FindAsync(id);
            if (season == null)
            {
                return null;
            }
            return SeasonMapper.MapToDetailedDTO(season);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var seasons = _dbContext.Set<Season>().Where(seasons => ids.Contains(seasons.Id)).ToList();
            if (seasons.Count == 0)
            {
                return false;
            }
            _dbContext.Set<Season>().RemoveRange(seasons);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
