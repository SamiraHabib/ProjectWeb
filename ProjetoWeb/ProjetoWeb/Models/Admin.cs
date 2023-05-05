using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class Admin
    {
        [Key]
        public int IdAdmin { get; set; }
        public string Name { get; set; }
        public string SocialName { get; set; }
    }
}
