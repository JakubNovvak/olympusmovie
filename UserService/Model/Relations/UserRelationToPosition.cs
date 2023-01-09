using System.Runtime.CompilerServices;

namespace UserService.Model.Relations
{
    public class UserRelationToPosition
    {
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public string TypeOfRelation { get; set; } = null!;
        public int RelatedPositionId { get; set; }
        public string RelatedPositionType { get; set; } = null!;
    }
}
