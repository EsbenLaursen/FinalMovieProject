using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace MyMovieShopAdmin.DAL
{
    public class MovieShopDBContext : DbContext
    {
        public MovieShopDBContext() : base("MyMovieShopDB")
        {
            Database.SetInitializer<MovieShopDBContext>(new MovieShopInitializer());
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasMany<Movie>(m => m.Movies).WithMany(g => g.Genres);

            modelBuilder.Entity<Order>().HasMany<Movie>(o => o.Movies);

            modelBuilder.Entity<Order>().HasRequired<Customer>(s => s.Customer).WithMany(o => o.Orders);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
    }
}