using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rabaswende002.Models;
using System.ComponentModel.DataAnnotations;

namespace Rabaswende002.ViewModel
{
    public class NewMovieViewModel
    {
       
        public IEnumerable<Genre> Genres { set; get; }
        public string Title;
        [Required]
        [MaxLength(225)]
        public string Name { get; set; }

        public int? Id { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        
        [Required]
        [Range(0, 20)]
        [Display(Name = "Number in Stock")]
        public byte? InStock { get; set; }

       
        [Required]
        [Display(Name = " Genre")]
        public byte? GenreId { get; set; }

        public NewMovieViewModel()
        {
            Id = 0;
        }
        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            InStock = movie.InStock;
            GenreId = movie.GenreId;

        }
    }
}