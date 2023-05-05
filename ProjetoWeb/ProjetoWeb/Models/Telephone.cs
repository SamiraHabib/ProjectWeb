using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class Telephone
    {
        [Key]
        public int IdTelephone { get; set; }
        public int IdStudent { get; set; }
        public string Number { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Student Student { get; set; }
    }
}
