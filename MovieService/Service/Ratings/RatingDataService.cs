using Microsoft.EntityFrameworkCore;
using MovieService.ApiModel.Ratings;
using MovieService.Infrastructure;
using MovieService.Model;
using MovieService.Repository;

namespace MovieService.Service.Ratings
{
    public class RatingDataService : IRatingDataService
    {
        private readonly MovieDbContext _dbContext;

        public RatingDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(RatingDTO ratingDTO)
        {
            var rating = RatingMapper.MapToEntity(ratingDTO);
            var createdRating = await _dbContext.Set<Rating>().AddAsync(rating);
            
            if (createdRating == null)
            {
                return 0;
            }

            await _dbContext.SaveChangesAsync();
            return createdRating.Entity.Id;
        }

        public async Task<int> EditAsync(RatingDTO ratingDTO)
        {
            var ratingEntity = RatingMapper.MapToEntity(ratingDTO);
            var ratingToEdit = await _dbContext.Set<Rating>().FindAsync(ratingEntity.Id);
            
            if (ratingToEdit == null)
            {
                return 0;
            }

            ratingToEdit.Value = ratingEntity.Value;
            ratingToEdit.UserId = ratingEntity.UserId;
            ratingToEdit.MovieId = ratingEntity.MovieId;
            ratingToEdit.SeasonId = ratingEntity.SeasonId;
            await _dbContext.SaveChangesAsync();
            
            return ratingToEdit.Id;
        }

        public async Task<RatingDTO?> GetById(int id)
        {
            var rating = await _dbContext.Set<Rating>().FindAsync(id);
            if (rating == null)
            {
                return null;
            }
            return RatingMapper.MapToDTO(rating);
        }
        
        public async Task<RatingDTO?> GetByUserAndPosition(int userId, int positionId, string positionType)
        {
            var rating = await _dbContext.Set<Rating>()
                .Where(rating => rating.UserId == userId)
                .Where(rating => positionType == PositionTypeConstants.MOVIE ? rating.MovieId == positionId : rating.SeasonId == positionId)
                .FirstAsync();
            return rating != null ? RatingMapper.MapToDTO(rating) : null;
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var ratings = _dbContext.Ratings.Where(rating => ids.Contains(rating.Id)).ToList();
            if (ratings.Count == 0)
            {
                return false;
            }
            _dbContext.Ratings.RemoveRange(ratings);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
