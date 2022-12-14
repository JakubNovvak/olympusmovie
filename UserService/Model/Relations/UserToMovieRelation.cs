using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Model.Relations
{
    [Index(nameof(TypeOfRelation))]
    public class UserToMovieRelation : Relation
    {
        [Column("RelatedMovieId")]
        public override int RelatedObjectId { get; set; }
    }
}
