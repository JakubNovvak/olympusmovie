using PersonService.Model;
using PersonService.ApiModel;

namespace PersonService.Service
{
    public class PersonMapper
    {

        public static PersonDTO MapToDTO(Person person)
        {
            return new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Birthdate = person.Birthdate,
                SeriesId = new List<PersonMovie>(person.SeriesId),
                //MoviesId = person.MoviesId
                //Roles = new List<Role>(Select role where aktor się zgadza)
            };
        }
    }
}
