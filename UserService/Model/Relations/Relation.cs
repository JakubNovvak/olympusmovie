using System.Runtime.CompilerServices;

namespace UserService.Model.Relations
{
    public class Relation
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public string TypeOfRelation { get; set; } = null!;
        public virtual int RelatedObjectId { get; set; }
    }
}
