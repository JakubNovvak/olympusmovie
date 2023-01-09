using MovieService.ApiModel.Reviews;
using MovieService.Model;
using MovieService.Repository;

namespace MovieService.Service.Reviews
{
    public class ReviewDataService : IReviewDataService
    {
        private readonly MovieDbContext _dbContext;

        public ReviewDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(ReviewDTO reviewDTO)
        {
            var review = ReviewMapper.MapToEntity(reviewDTO);
            var createdReview = await _dbContext.Set<Review>().AddAsync(review);
            if (createdReview == null)
            {
                return 0;
            }

            await _dbContext.SaveChangesAsync();
            return createdReview.Entity.Id;
        }

        public async Task<int> EditAsync(ReviewDTO reviewDTO)
        {
            var reviewEntity = ReviewMapper.MapToEntity(reviewDTO);
            var reviewToEdit = await _dbContext.Set<Review>().FindAsync(reviewEntity.Id);
            
            if (reviewToEdit == null)
            {
                return 0;
            }

            reviewToEdit.Content = reviewEntity.Content;
            reviewToEdit.UserId = reviewEntity.UserId;
            reviewToEdit.RatingId = reviewEntity.RatingId;
            await _dbContext.SaveChangesAsync();
                
            return reviewToEdit.Id;
        }

        public IEnumerable<ReviewDTO> GetAll(Func<Review, bool> predicate)
        {
            return _dbContext.Set<Review>().Where(predicate)
                .Select(review => ReviewMapper.MapToDTO(review));
        }

        public async Task<ReviewDTO?> GetById(int id)
        {
            var review = await _dbContext.Set<Review>().FindAsync(id);
            if (review == null)
            {
                return null;
            }
            return ReviewMapper.MapToDTO(review);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var rewiews = _dbContext.Set<Review>().Where(movie => ids.Contains(movie.Id)).ToList();
            if (rewiews.Count == 0)
            {
                return false;
            }
            _dbContext.Set<Review>().RemoveRange(rewiews);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
