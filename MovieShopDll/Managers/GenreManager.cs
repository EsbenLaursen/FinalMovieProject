using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMovieShopAdmin.DAL;
using System.Data.Entity;

namespace MovieShopDll.Managers
{
    internal class GenreManager : AbstractManager<Genre>
    {
        public override List<Genre> Read(MovieShopDBContext ctx)
        {
            return ctx.Genres.Include("Movies").ToList();
        }

        public override Genre Read(MovieShopDBContext ctx, int id)
        {
            return ctx.Genres.Include("Movies").FirstOrDefault(x => x.Id == id);
        }

        public override Genre Create(MovieShopDBContext ctx, Genre t)
        {
            ctx.Genres.Add(t);
            ctx.SaveChanges();
            return t;
        }


        public override bool Delete(MovieShopDBContext ctx, int id)
        {
            Genre o = ctx.Genres.FirstOrDefault(x => x.Id == id);
            ctx.Entry(o).State = EntityState.Deleted;
            return true;
        }

        public override Genre Update(MovieShopDBContext ctx, Genre t)
        {
            ctx.Entry(t).State = EntityState.Modified;
            return t;
        }
    }
}
