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
           // Database.SetInitializer<MovieShopDBContext>(new DropCreateDatabaseAlways<MovieShopDBContext>());

            //Database.SetInitializer<MovieShopDBContext>(new CreateDatabaseIfNotExists<MovieShopDBContext>());
            //Database.SetInitializer<MovieShopDBContext>(new DropCreateDatabaseIfModelChanges<MovieShopDBContext>());
            Database.SetInitializer<MovieShopDBContext>(new MovieShopInitializer());
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        
    }
}