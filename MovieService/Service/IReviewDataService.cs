using MovieService.ApiModel;

namespace MovieService.Service
{
    public interface IReviewDataService
    {
        Task<int> AddAsync(ReviewDTO reviewDTO);
        IEnumerable<ReviewDTO> GetAll();
        Task<bool> Remove(int id);
        Task<int> EditAsync(ReviewDTO reviewDTO);
    }
}
