using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Rabaswende002.Dtos;

namespace Rabaswende002.Models
{
    public class Rental
    {
        public int RentalId { get; set; }

        [Required]
        public Customer CustomerId { get; set; }

        [Required]
        public Movie MovieIds { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}