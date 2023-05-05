using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class Payment
    {
        [Key]
        public int IdPayment { get; set; }
        public int IdAdmin { get; set; }
        public Admin Admin { get; set; }
        public int IdStudent { get; set; }
        public Student Student { get; set; }
        public int IdStatus { get; set; }
        public Status Status { get; set; }
        public int IdPaymentType { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime DueDate { get; set; }
        public string Invoice { get; set; }
        public DateTime? DatePayment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
