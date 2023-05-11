using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public int? IdAdmin { get; set; }
        public int? IdStudent { get; set; }
        public int? IdProfile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Admin? Admin { get; set; }
        public Student? Student { get; set; }
        public Profile? Profile { get; set; }
    }
}
