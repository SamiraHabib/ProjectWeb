using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class Status
    {
        [Key]
        public int IdStatus { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
