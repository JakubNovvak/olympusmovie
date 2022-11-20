using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;

namespace PersonService.Model
{
    [PrimaryKey(nameof(PersonId), nameof(MovieId))]

    public class PersonMovie
    {
        public int PersonId { get; set; }
        public int MovieId { get; set; }
    }
}
