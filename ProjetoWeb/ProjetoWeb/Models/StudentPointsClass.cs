namespace ProjetoWeb.Models
{
    public class StudentPointsClass
    {
        public int IdStudent { get; set; }
        public int IdExercise { get; set; }
        public int Points { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Student Student { get; set; }
        public Exercise Exercise { get; set; }
    }
}
