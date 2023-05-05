using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class PaymentType
    {
        [Key]
        public int IdPaymentType { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
