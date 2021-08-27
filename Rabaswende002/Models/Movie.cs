using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Rabaswende002.Models
{
    public class Movie
    {
       
        [Required]
        [MaxLength(225)]
        public string Name { get; set; }

        public int Id { get; set; }
       
        [Required]
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime AddedDate { get; set; }
        [Required]
        [Range(0, 20)]
        [Display(Name ="Number in Stock")]
        public byte InStock { get; set; } 

        
        
        [Display(Name="Number available")]
        public byte NumberAvailable { get; set; }
        
        public Genre Genre { get; set; }
        [Required]
        [Display(Name =" Genre")]
        public byte GenreId { get; set; }
    }
}