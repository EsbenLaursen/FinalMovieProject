
using MovieShopDll.Entities;
using MyMovieShopAdmin.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDll.Managers
{
    
    internal class MovieManager : AbstractManager<Movie>
    {
        public override List<Movie> Read(MovieShopDBContext ctx)
        {
            ctx.SaveChanges();
            return ctx.Movies.Include("Genre").ToList();
        }

        public override Movie Read(MovieShopDBContext ctx, int id)
        {
            ctx.SaveChanges();
            return ctx.Movies.Include("Genre").FirstOrDefault(x => x.Id == id);
        }

        public override Movie Create(MovieShopDBContext ctx, Movie t)
        {
            ctx.Movies.Add(t);
            ctx.SaveChanges();
            return t;
        }

        public override bool Delete(MovieShopDBContext ctx, int id)
        {
            Movie o = ctx.Movies.FirstOrDefault(x => x.Id == id);
            ctx.Movies.Remove(o);
            ctx.SaveChanges();
            return true;
        }

        public override Movie Update(MovieShopDBContext ctx, Movie t)
        {
            ctx.Entry(t).State = EntityState.Modified;
            ctx.SaveChanges();
            return t;
        }
    }
}
