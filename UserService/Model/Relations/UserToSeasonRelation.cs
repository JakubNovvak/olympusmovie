using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Model.Relations
{
    [Index(nameof(TypeOfRelation))]
    public class UserToSeasonRelation : Relation
    {   
        [Column("RelatedSeasonId")]
        public override int RelatedObjectId { get; set; }
        
        public int EpisodeCount { get; set; }
    }
}
