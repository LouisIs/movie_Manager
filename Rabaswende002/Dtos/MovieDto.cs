using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rabaswende002.Dtos
{
    public class MovieDto
    {
        [Required]
        [MaxLength(225)]
        public string Name { get; set; }

        public int Id { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime AddedDate { get; set; }
        
        [Required]
        [Range(0, 20)]
        public byte InStock { get; set; }

        public GenreDto Genre { get; set; }
       
        [Required]
        public byte GenreId { get; set; }
    }
}