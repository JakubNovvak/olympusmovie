using MovieService.ApiModel;
using MovieService.Repository;

namespace MovieService.Service
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
            var createdReview = await _dbContext.Reviews.AddAsync(review);
            if (createdReview != null)
            {
                await _dbContext.SaveChangesAsync();
                return createdReview.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(ReviewDTO reviewDTO)
        {
            var reviewEntity = ReviewMapper.MapToEntity(reviewDTO);
            var reviewToEdit = _dbContext.Reviews.FirstOrDefault(movie => movie.Id == reviewEntity.Id);
            if (reviewToEdit != null)
            {
                reviewToEdit.Content = reviewEntity.Content;
                reviewToEdit.UserId = reviewEntity.UserId;
                reviewToEdit.RatingId = reviewEntity.RatingId;
                reviewToEdit.Comments = reviewEntity.Comments;
                await _dbContext.SaveChangesAsync();
                return reviewToEdit.Id;
            }
            return 0;
        }

        public IEnumerable<ReviewDTO> GetAll()
        {
            return _dbContext.Reviews.Select(review => ReviewMapper.MapToDTO(review));
        }

        public async Task<ReviewDTO?> GetById(int id)
        {
            var review = await _dbContext.Reviews.FindAsync(id);
            if (review == null)
            {
                return null;
            }
            return ReviewMapper.MapToDTO(review);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var rewiews = _dbContext.Reviews.Where(movie => ids.Contains(movie.Id)).ToList();
            if (rewiews.Count == 0)
            {
                return false;
            }
            _dbContext.Reviews.RemoveRange(rewiews);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
