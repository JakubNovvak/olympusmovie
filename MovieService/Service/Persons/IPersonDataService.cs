using MovieService.ApiModel.Persons;

namespace MovieService.Service.Persons
{
    public interface IPersonDataService
    {
        IEnumerable<int> GetAll();
        Task<PersonDTO?> GetById(int id);
        Task<int> AddAsync(PersonDTO personDTO);
        Task<int> EditAsync(PersonDTO personDTO);
        Task<bool> RemoveRange(ISet<int> ids);
    }
}
