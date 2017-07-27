using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VidlyF.Web.Models;

namespace VidlyF.Web.ViewModels
{
    public class CustomerFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        [Required]
        [Display(Name = "Memebership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateTime { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                return (Id != 0) ? "Update" : "Create";
            }

        }
    }
}