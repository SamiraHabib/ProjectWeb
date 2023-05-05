using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class Exercise
    {
        [Key]
        public int IdExercise { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
