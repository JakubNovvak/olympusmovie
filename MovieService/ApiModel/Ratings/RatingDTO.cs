using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel.Ratings
{
    public class RatingDTO
    {
        public int Id { get; set; }
        public int value { get; set; }
        public int UserId { get; set; }
        public int PositionId { get; set; }
        public string PositionType { get; set; } = null!;
    }
}
