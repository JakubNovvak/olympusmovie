using MovieService.ApiModel.Reviews;
using MovieService.Model;

namespace MovieService.Service.Reviews
{
    public interface IReviewDataService
    {
        Task<int> AddAsync(ReviewDTO reviewDTO);
        IEnumerable<ReviewDTO> GetAll(Func<Review, bool> predicate);
        Task<bool> RemoveRange(ISet<int> ids);
        Task<int> EditAsync(ReviewDTO reviewDTO);
        Task<ReviewDTO?> GetById(int id);
    }
}
