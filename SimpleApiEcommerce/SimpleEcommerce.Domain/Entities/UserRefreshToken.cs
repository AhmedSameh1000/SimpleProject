using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleEcommerce.Domain.Entities
{
    public class UserRefreshToken
    {
        public string Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
    }
}