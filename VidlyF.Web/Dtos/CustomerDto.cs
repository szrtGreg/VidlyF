using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyF.Web.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }

        public DateTime? DateTime { get; set; }
    }
}