using MovieService.ApiModel;
using MovieService.Repository;

namespace MovieService.Service
{
    public class CommentDataService : ICommentDataService
    {
        private readonly MovieDbContext _dbContext;

        public CommentDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(CommentDTO commentDTO)
        {
            var comment = CommentMapper.MapToEntity(commentDTO);
            var createComment = await _dbContext.Comments.AddAsync(comment);
            if (createComment != null)
            {
                await _dbContext.SaveChangesAsync();
                return createComment.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(CommentDTO commentDTO)
        {
            var commentEntity = CommentMapper.MapToEntity(commentDTO);
            var findComment = _dbContext.Comments.FirstOrDefault(comment => comment.Id == commentEntity.Id);
            if (findComment != null)
            {
                findComment.Content = commentEntity.Content;
                await _dbContext.SaveChangesAsync();
                return findComment.Id;
            }
            return 0;
        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Comments.Select(comment => comment.Id);
        }

        public async Task<CommentDTO?> GetById(int id)
        {
            var comment = await _dbContext.Comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            return CommentMapper.MapToDTO(comment);
        }

        public async Task<bool> Remove(int id)
        {
            var comment = _dbContext.Comments.FirstOrDefault(comment => comment.Id == id);
            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
