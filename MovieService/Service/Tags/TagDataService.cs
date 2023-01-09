using MovieService.ApiModel.Tags;
using MovieService.Model;
using MovieService.Repository;

namespace MovieService.Service.Tags
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
            var createTag = await _dbContext.Set<Tag>().AddAsync(tag);
            
            if (createTag == null)
            {
                return 0;
            }

            await _dbContext.SaveChangesAsync();
            return createTag.Entity.Id;

        }

        public async Task<int> EditAsync(TagDTO tagDTO)
        {
            var tagEntity = TagMapper.MapToEntity(tagDTO);
            var foundTag = await _dbContext.Set<Tag>().FindAsync(tagEntity.Id);
            
            if (foundTag == null)
            {
                return 0;
            }

            foundTag.Name = tagEntity.Name;
            foundTag.Description = tagEntity.Description;
            await _dbContext.SaveChangesAsync();
            
            return foundTag.Id;

        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Set<Tag>().Select(tag => tag.Id);
        }

        public async Task<TagDTO?> GetById(int id)
        {
            var tag = await _dbContext.Set<Tag>().FindAsync(id);
            if (tag == null)
            {
                return null;
            }
            return TagMapper.MapToDTO(tag);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var tags = _dbContext.Set<Tag>().Where(tag => ids.Contains(tag.Id)).ToList();
            if (tags.Count == 0)
            {
                return false;
            }
            _dbContext.Set<Tag>().RemoveRange(tags);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
