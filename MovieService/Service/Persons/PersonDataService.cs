using MovieService.ApiModel.Persons;
using MovieService.Model;
using MovieService.Repository;

namespace MovieService.Service.Persons
{
    public class PersonDataService : IPersonDataService
    {
        private readonly MovieDbContext _dbContext;

        public PersonDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(PersonDTO personDTO)
        {
            var person = PersonMapper.MapToEntity(personDTO);
            var createPerson = await _dbContext.Set<Person>().AddAsync(person);
            if (createPerson != null)
            {
                await _dbContext.SaveChangesAsync();
                return createPerson.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(PersonDTO personDTO)
        {
            var personEntity = PersonMapper.MapToEntity(personDTO);
            var foundPerson = await _dbContext.Set<Person>().FindAsync(personEntity.Id);
            if (foundPerson == null)
            {
                return 0;
            }

            foundPerson.Name = personEntity.Name;
            foundPerson.Surname = personEntity.Surname;
            foundPerson.Birthdate = personEntity.Birthdate;
            foundPerson.Photo = personEntity.Photo;
            await _dbContext.SaveChangesAsync();
            
            return foundPerson.Id;
        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Persons.Select(person => person.Id);
        }

        public async Task<PersonDTO?> GetById(int id)
        {
            var person = await _dbContext.Set<Person>().FindAsync(id);
            if (person == null)
            {
                return null;
            }
            return PersonMapper.MapToDTO(person);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var persons = _dbContext.Persons.Where(person => ids.Contains(person.Id)).ToList();
            if (persons.Count == 0)
            {
                return false;
            }
            _dbContext.Persons.RemoveRange(persons);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}