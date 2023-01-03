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

        public Task<int> AddAsync(ReviewDTO reviewDTO)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditAsync(ReviewDTO reviewDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReviewDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
