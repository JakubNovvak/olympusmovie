using MovieService.ApiModel.Ratings;

namespace MovieService.Service.Ratings
{
    public interface IRatingDataService
    {
        Task<int> AddAsync(RatingDTO ratingDTO);
        Task<RatingDTO?> GetById(int id);
        Task<bool> RemoveRange(ISet<int> ids);
        Task<int> EditAsync(RatingDTO ratingDTO);
    }
}
