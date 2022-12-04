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
            RelatedUserId = relatedUserId;
            RelatedMovieId = relatedMovieId;
        }

        public int RelatedUserId { get; set; }
        public int RelatedMovieId { get; set; }
    }
}
