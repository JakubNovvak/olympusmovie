using MovieService.ApiModel.Comments;
using MovieService.Model;
using MovieService.Repository;

namespace MovieService.Service.Comments
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
            var createComment = await _dbContext.Set<Comment>().AddAsync(comment);
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
            var foundComment = await _dbContext.Set<Comment>().FindAsync(commentEntity.Id);
            if (foundComment != null)
            {
                foundComment.Content = commentEntity.Content;
                foundComment.ReviewId = commentEntity.ReviewId;
                foundComment.UserId = commentEntity.UserId;
                await _dbContext.SaveChangesAsync();
                return foundComment.Id;
            }
            return 0;
        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Set<Comment>().Select(comment => comment.Id);
        }

        public async Task<CommentDTO?> GetById(int id)
        {
            var comment = await _dbContext.Set<Comment>().FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            return CommentMapper.MapToDTO(comment);
        }

        public async Task<bool> Remove(int id)
        {
            var comment = await _dbContext.Set<Comment>().FindAsync(id);
            if (comment == null)
            {
                return false;
            }
            _dbContext.Set<Comment>().Remove(comment);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
