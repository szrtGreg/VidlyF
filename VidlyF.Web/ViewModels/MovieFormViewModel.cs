using System;
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
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public byte NumberInStock { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public byte NumberAvailable { get; set; }

    }
}