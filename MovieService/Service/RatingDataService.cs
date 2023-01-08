using MovieService.ApiModel;
using MovieService.Repository;

namespace MovieService.Service
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
            var createdRating = await _dbContext.Ratings.AddAsync(rating);
            if (createdRating != null)
            {
                await _dbContext.SaveChangesAsync();
                return createdRating.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(RatingDTO ratingDTO)
        {
            var ratingEntity = RatingMapper.MapToEntity(ratingDTO);
            var ratingToEdit = _dbContext.Ratings.FirstOrDefault(rating => rating.Id == ratingEntity.Id);
            if (ratingToEdit != null)
            {
                ratingToEdit.value = ratingEntity.value;
                ratingToEdit.UserId = ratingEntity.UserId;
                ratingToEdit.PositionId = ratingEntity.PositionId;
                ratingEntity.PositionType = ratingEntity.PositionType;

                await _dbContext.SaveChangesAsync();
                return ratingToEdit.Id;
            }
            return 0;
        }

        public async Task<RatingDTO?> GetById(int id)
        {
            var rating = await _dbContext.Ratings.FindAsync(id);
            if (rating == null)
            {
                return null;
            }
            return RatingMapper.MapToDTO(rating);
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
