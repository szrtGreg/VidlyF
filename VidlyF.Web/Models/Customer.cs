using System.ComponentModel.DataAnnotations;

namespace VidlyF.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}