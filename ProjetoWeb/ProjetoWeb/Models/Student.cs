namespace ProjetoWeb.Models
{
    public class Student
    {
        public int IdStudent { get; set; }
        public int? IdUser { get; set; }
        public int? IdGenre { get; set; }
        public int? IdAddress { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool? IsBlocked { get; set; }
        public string BlockDescription { get; set; }
        public byte[] ImageProfile { get; set; }

        public User User { get; set; }
        public Genre Genre { get; set; }
        public Address Address { get; set; }
    }
}
