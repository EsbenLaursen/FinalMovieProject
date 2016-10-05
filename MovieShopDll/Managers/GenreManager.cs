﻿using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMovieShopAdmin.DAL;

namespace MovieShopDll.Managers
{
    internal class GenreManager : AbstractManager<Genre>
    {
        public override List<Genre> Read(MovieShopDBContext ctx)
        {
            return ctx.Genres.ToList();
        }

        public override Genre Read(MovieShopDBContext ctx, int id)
        {
            return ctx.Genres.FirstOrDefault(x => x.Id == id);
        }

        public override Genre Create(MovieShopDBContext ctx, Genre t)
        {
            ctx.Genres.Add(t);
            return t;
        }


        public override bool Delete(MovieShopDBContext ctx, int id)
        {
            Genre o = ctx.Genres.FirstOrDefault(x => x.Id == id);
            ctx.Genres.Remove(o);
            return true;
        }

        public override Genre Update(MovieShopDBContext ctx, Genre t)
        {
            throw new NotImplementedException();
        }
    }
}