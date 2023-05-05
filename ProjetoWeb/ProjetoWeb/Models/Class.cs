namespace ProjetoWeb.Models
{
    public class Class
    {
        public int IdClass { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
