using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Model.Relations
{
    [Index(nameof(TypeOfRelation))]
    public class UserToSeriesRelation : Relation
    {
        [Column("RelatedSeriesId")]
        public override int RelatedObjectId { get; set; }
    }
}
