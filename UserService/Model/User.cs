using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace UserService.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("surname")]
        public string Surname { get; set; } = null!;

        [Column("user_name")]
        public string UserName { get; set; } = null!;

        [Column("email")]
        public string Email { get; set; } = null!;

        [Column("photo")]
        public string Photo { get; set; } = null!;
    }
}
