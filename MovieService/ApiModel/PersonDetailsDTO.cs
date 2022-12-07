namespace MovieService.ApiModel
{
    public class PersonDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateOnly Birthdate { get; set; }
        public string Photo { get; set; } = null!;
        public ICollection<SeriesDTO> Series { get; set; } = null!;
        public ICollection<MovieDTO> Movies { get; set; } = null!;
        public ICollection<RoleDTO> Roles { get; set; } = null!;
    }
}
