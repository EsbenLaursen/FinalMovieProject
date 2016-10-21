using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMovieShopAdmin.DAL
{
    public class MovieShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MovieShopDBContext>
    {
        protected override void Seed(MovieShopDBContext context)
        {
            List<Genre> Genres = new List<Genre>();
            List<Customer> Customers = new List<Customer>();
            List<Movie> Movies = new List<Movie>();
            List<Order> Orders = new List<Order>();

            

            Customer c = new Customer() { FirstName="Esben", LastName="Laursen", City = "Esbjerg", StreetName = "Skolegade", StreetNumber = 63, ZipCode = 6700, Email="Esben.laursen@gmail.com", password="123", Role="admin"};
            Customer c2 = new Customer() { FirstName = "Emil", LastName = "Dall", City = "Esbjerg", StreetName = "Jyllandsgade", StreetNumber = 123, ZipCode = 6700, Email = "Dallefar@boobs.com", password = "123", Role = "user" };
            Customer c3 = new Customer() { FirstName = "Anders", LastName = "G", City = "Esbjerg", StreetName = "Rævestræde", StreetNumber = 5, ZipCode = 6700, Email = "Esben.laursen@gmail.com", password = "123", Role = "user" };
            Customer c4 = new Customer() { FirstName = "Torsten", LastName = "Sladrehank", City = "Esbjerg", StreetName = "Sejvej", StreetNumber = 52, ZipCode = 6800, Email = "Esben.laursen@gmail.com", password = "123", Role = "user" };
            Customers.Add(c);
            Customers.Add(c2);
            Customers.Add(c3);
            Customers.Add(c4);

            Genre g1 = new Genre() { Id = 1, Name = "Action"};
            Genre g2 = new Genre() { Id = 2, Name = "Anime" };
            Genre g3 = new Genre() { Id = 3, Name = "Horror" };
            Genre g4 = new Genre() { Id = 4, Name = "Adventure" };
            Genre g5 = new Genre() { Id = 5, Name = "Comedy" };
            Genres.Add(g1);
            Genres.Add(g2);
            Genres.Add(g3);
            Genres.Add(g4);
            Genres.Add(g5);


            Movie m1 = new Movie() { Id = 1, Title = "Civil war", Genres = new List<Genre>() { g1, g2},  Price = 20.0, Year = 2016, ImageUrl = "../Content/Images/civilwar.jpg", TrailerUrl = "https://www.youtube.com/embed/dKrVegVI0Us" };
            Movie m2 = new Movie() { Id = 2, Title = "Deadpool", Genres = new List<Genre>() { g3, g2 }, Price = 20.0, Year = 2016, ImageUrl = "../Content/Images/deadpool.jpg",TrailerUrl = "https://www.youtube.com/embed/Xithigfg7dA" };
            Movie m3 = new Movie() {Id = 3, Title = "Fight club", Genres = new List<Genre>() { g4, g2 }, Price = 20.0, Year = 2016, ImageUrl = "../Content/Images/fightclub.jpg", TrailerUrl = "https://www.youtube.com/embed/SUXWAEX2jlg" };
            Movie m4 = new Movie() {Id = 4, Title = "Inception",  Genres = new List<Genre>() { g1, g2 }, Price = 20.0,Year = 1999, ImageUrl = "../Content/Images/inception.jpg",TrailerUrl = "https://www.youtube.com/embed/YoHD9XEInc0" };
            Movie m5 = new Movie() {Id = 5,Title = "Seven", Genres = new List<Genre>() { g1, g2 }, Price = 20.0,Year = 1995, ImageUrl = "../Content/Images/seven.jpg",TrailerUrl = "https://www.youtube.com/embed/znmZoVkCjpI" };
            Movie m6 = new Movie() {Id = 6, Title = "Saving private ryan", Genres = new List<Genre>() { g1, g2 }, Price = 20.0, Year = 1998, ImageUrl = "../Content/Images/savingprivateryan.jpg",TrailerUrl = "https://www.youtube.com/embed/HyVuRpjmaAI"};
            Movie m7 = new Movie() {Id = 7,Title = "Gladiator", Genres = new List<Genre>() { g1, g4 }, Price = 20.0, Year = 2016,ImageUrl = "../Content/Images/gladiator.jpg",TrailerUrl = "https://www.youtube.com/embed/owK1qxDselE" };
            Movie m8 = new Movie(){ Id = 8,Title = "Egde of tomorrow", Genres = new List<Genre>() { g1, g2 }, Price = 20.0, Year = 2016,ImageUrl = "../Content/Images/edgeoftomorrow.jpg",TrailerUrl = "https://www.youtube.com/embed/vw61gCe2oqI" };
            Movie m9 = new Movie() { Id = 9, Title = "Django", Genres = new List<Genre>() { g2, g4 }, Price = 20.0, Year = 2016, ImageUrl = "../Content/Images/django2.jpg", TrailerUrl = "https://www.youtube.com/embed/eUdM9vrCbow" };
            Movie m10 = new Movie() { Id = 10, Title = "The wolf of wall street", Genres = new List<Genre>() { g3, g2 }, Price = 20.0, Year = 2016, ImageUrl = "../Content/Images/thewolf2.jpg", TrailerUrl = "https://www.youtube.com/embed/idAVRvQeYAE" };
            Movie m11 = new Movie() { Id = 11, Title = "Mad max", Genres = new List<Genre>() { g2, g3 }, Price = 20.0, Year = 2016, ImageUrl = "../Content/Images/madmax2.jpg", TrailerUrl = "https://www.youtube.com/embed/vjBb4SZ0F6Q" };
            Movies.Add(m1);
            Movies.Add(m2);
            Movies.Add(m3);
            Movies.Add(m4);
            Movies.Add(m5);
            Movies.Add(m6);
            Movies.Add(m7);
            Movies.Add(m8);
            Movies.Add(m9);
            Movies.Add(m10);
            Movies.Add(m11);


            Order order = new Order() { Customer = c, Movies=Movies, Date=DateTime.Now };
            Order order2 = new Order() { Customer = c, Date = DateTime.Now.AddDays(3) };
            Orders.Add(order);
            Orders.Add(order2);

            foreach (var o in Orders)
            {
                context.Orders.Add(o);
            }
            foreach (var movie in Movies)
            {
                context.Movies.Add(movie);
            }
            foreach (var genre in Genres )
            {
                context.Genres.Add(genre);
            }
            foreach (var cus in Customers)
            {
                context.Customer.Add(cus);

            }
            
            context.SaveChanges();
          
            
        }
    }
}