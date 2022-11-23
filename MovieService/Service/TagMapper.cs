using MovieService.ApiModel;
using MovieService.Model;

namespace MovieService.Service
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

        public static Tag MapToEntity(TagDTO tagDTO, bool isNew)
        {
            if (isNew)
            {
                return new Tag
                {
                    Id = tagDTO.Id,
                    Name = tagDTO.Name,
                    Description = tagDTO.Description,
                    Movies = new List<Movie>(),
                    Series = new List<Series>()
                };
            }
            else
            {
                return new Tag
                {
                    Id = tagDTO.Id,
                    Name = tagDTO.Name,
                    Description = tagDTO.Description
                };
            }
        }
    }
}
