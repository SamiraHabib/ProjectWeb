namespace ProjetoWeb.Models
{
    public class StudentCheckin
    {
        public int IdStudent { get; set; }
        public int IdClass { get; set; }
        public DateTime DateTime { get; set; }

        public Student Student { get; set; }
        public Class Class { get; set; }
    }
}
