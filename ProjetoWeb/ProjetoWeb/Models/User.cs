namespace ProjetoWeb.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public int IdProfile { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SocialName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Profile Profile { get; set; }
    }
}
