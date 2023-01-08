using MovieService.ApiModel;

namespace MovieService.Service
{
    public interface IReviewDataService
    {
        Task<int> AddAsync(ReviewDTO reviewDTO);
        IEnumerable<ReviewDTO> GetAll();
        Task<bool> RemoveRange(ISet<int> ids);
        Task<int> EditAsync(ReviewDTO reviewDTO);
        Task<ReviewDTO?> GetById(int id);
    }
}
