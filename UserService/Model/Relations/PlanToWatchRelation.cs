using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Model.Relations
{
    public class PlanToWatchRelation
    {
        public PlanToWatchRelation()
        {

        }

        public PlanToWatchRelation(int relatedUserId, int relatedMovieId)
        {
            UserId = relatedUserId;
            RelatedMovieId = relatedMovieId;
        }

        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int RelatedMovieId { get; set; }
    }
}
