using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web;


namespace Rabaswende002.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {   
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<MembershipType> membershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}