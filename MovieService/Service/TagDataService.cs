using MovieService.ApiModel;
using MovieService.Repository;

namespace MovieService.Service
{
    public class TagDataService : ITagDataService
    {
        private readonly MovieDbContext _dbContext;

        public TagDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(TagDTO tagDTO)
        {
            var tag = TagMapper.MapToEntity(tagDTO);
            var createTag = await _dbContext.Tags.AddAsync(tag);
            if (createTag != null)
            {
                await _dbContext.SaveChangesAsync();
                return createTag.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(TagDTO tagDTO)
        {
            var tagEntity = TagMapper.MapToEntity(tagDTO);
            var findTag = _dbContext.Tags.FirstOrDefault(tag => tag.Id == tagEntity.Id);
            if (findTag != null)
            {
                findTag.Name = tagEntity.Name;
                findTag.Description = tagEntity.Description;
                await _dbContext.SaveChangesAsync();
                return findTag.Id;
            }
            return 0;
        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Movies.Select(tag => tag.Id);
        }

        public async Task<TagDTO?> GetById(int id)
        {
            var tag = await _dbContext.Tags.FindAsync(id);
            if (tag == null)
            {
                return null;
            }
            return TagMapper.MapToDTO(tag);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var tags = _dbContext.Tags.Where(tag => ids.Contains(tag.Id)).ToList();
            if (tags.Count == 0)
            {
                return false;
            }
            _dbContext.Tags.RemoveRange(tags);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
