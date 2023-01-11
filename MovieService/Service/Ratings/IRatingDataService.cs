using MovieService.ApiModel.Ratings;

namespace MovieService.Service.Ratings
{
    public interface IRatingDataService
    {
        Task<int> AddOrEditAsync(RatingDTO ratingDTO);
        Task<RatingDTO?> GetById(int id);
        Task<bool> RemoveRange(ISet<int> ids);
        Task<int> EditAsync(RatingDTO ratingDTO);
        Task<RatingDTO?> GetByUserAndPosition(int userId, int positionId, string positionType);
    }
}
