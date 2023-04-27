namespace ProjetoWeb.Models
{
    public class PaymentType
    {
        public int IdPaymentType { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
