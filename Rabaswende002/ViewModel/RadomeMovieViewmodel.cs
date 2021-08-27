using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rabaswende002.Models;

namespace Rabaswende002.ViewModel
{
    public class RadomeMovieViewmodel
    {
        public List<Movie> Movie { get; set; }
        public List<Customer> Customers { get; set; }
        public Movie movies { get; set; }
    }
}