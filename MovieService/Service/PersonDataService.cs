using MovieService.ApiModel;
using MovieService.Repository;

namespace MovieService.Service
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
            var person = PersonMapper.MapToEntity(personDTO, true);
            var createPerson = await _dbContext.Persons.AddAsync(person);
            if (createPerson != null)
            {
                await _dbContext.SaveChangesAsync();
                return createPerson.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(PersonDTO personDTO)
        {
            var personEntity = PersonMapper.MapToEntity(personDTO, false);
            var findPerson = _dbContext.Persons.FirstOrDefault(person => person.Id == personEntity.Id);
            if (findPerson != null)
            {
                findPerson.Name = personEntity.Name;
                findPerson.Surname = personEntity.Surname;
                findPerson.Birthdate = personEntity.Birthdate;
                findPerson.Photo = personEntity.Photo;
                await _dbContext.SaveChangesAsync();
                return findPerson.Id;
            }
            return 0;
        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Persons.Select(person => person.Id);
        }

        public async Task<PersonDTO?> GetById(int id)
        {
            var person = await _dbContext.Persons.FindAsync(id);
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