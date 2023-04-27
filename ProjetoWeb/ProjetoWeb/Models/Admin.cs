namespace ProjetoWeb.Models
{
    public class Admin
    {
        public int IdAdmin { get; set; }
        public int IdUser { get; set; }

        public User User { get; set; }
    }
}
