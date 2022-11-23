using MovieService.ApiModel;

namespace MovieService.Service
{
    public interface ITagDataService
    {
        Task<int> AddAsync(TagDTO tagDTO);
        IEnumerable<int> GetAll();
        Task<bool> RemoveRange(ISet<int> ids);
        Task<TagDTO?> GetById(int id);
        Task<int> EditAsync(TagDTO tagDTO);
    }
}
