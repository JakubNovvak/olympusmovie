using MovieService.ApiModel.Tags;
using MovieService.Model;

namespace MovieService.Service.Tags
{
    public class TagMapper
    {
        public static TagDTO MapToDTO(Tag tag)
        {
            return new TagDTO
            {
                Id = tag.Id,
                Name = tag.Name,
                Description = tag.Description
            };
        }

        public static Tag MapToEntity(TagDTO tagDTO)
        {
            return new Tag
            {
                Id = tagDTO.Id,
                Name = tagDTO.Name,
                Description = tagDTO.Description,
                Movies = new List<Movie>(),
                Seasons = new List<Season>()
            };
        }
    }
}
