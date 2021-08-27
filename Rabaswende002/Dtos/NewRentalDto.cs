using Rabaswende002.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Rabaswende002.App_Start;


namespace Rabaswende002.Dtos
{
    public class NewRentalDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public List<int> MovieIds { get; set; }

        
    }
}