using Microsoft.EntityFrameworkCore;

namespace UserService.Model.Relations
{
    [Index(nameof(TypeOfRelation))]
    public class UserToMovieRelation
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public int RelatedMovieId { get; set; }
        public string TypeOfRelation { get; set; } = null!;
    }
}
