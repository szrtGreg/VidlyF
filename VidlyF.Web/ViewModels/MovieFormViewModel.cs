using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VidlyF.Web.Models;

namespace VidlyF.Web.ViewModels
{
    public class MovieFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        [Display(Name = "Mumber in stock")]
        public byte? NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genres")]
        public byte GenreId { get; set; }



        public string Heading { get; set; }

        public string Action
        {
            get
            {
                return (Id != 0) ? "Update" : "Create";
            }

        }

        public IEnumerable<Genre> Genres { get; set; }

    }
}