using MovieService.ApiModel;

namespace MovieService.Service
{
    public interface ICommentDataService
    {
        Task<int> AddAsync(CommentDTO commentDTO);
        IEnumerable<int> GetAll();
        Task<bool> Remove (int id);
        Task<CommentDTO?> GetById(int id);
        Task<int> EditAsync(CommentDTO commentDTO);
    }
}
