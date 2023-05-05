using System.ComponentModel.DataAnnotations;

namespace ProjetoWeb.Models
{
    public class ContentManagement
    {
        [Key]
        public int IdContentManagement { get; set; }
        public int IdAddress { get; set; }
        public int IdAdmin { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string AboutDescription { get; set; }
        public string MainImageUrl { get; set; }
        public string LogoImageUrl { get; set; }
        public string PageTitle { get; set; }
        public bool IsMain { get; set; }
        public string Whatsapp { get; set; }
        public string Telephone { get; set; }
        public string EmailContact { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Address Address { get; set; }
        public virtual Admin Admin { get; set; }
    }
}
