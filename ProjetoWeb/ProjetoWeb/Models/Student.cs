using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class Student
    {
        [Key]
        public int IdStudent { get; set; }
        public int? IdGenre { get; set; }
        public int? IdAddress { get; set; }
        public string Name { get; set; }
        public string SocialName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsBlocked { get; set; }
        public string BlockDescription { get; set; }
        public string ImageProfile { get; set; }
        //passar ImageProfile para string - mudar as migrations e a controller de usuário e student
        
        public Genre Genre { get; set; }
        public Address Address { get; set; }
    }
}
