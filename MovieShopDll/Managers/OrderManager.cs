using MovieShopDll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMovieShopAdmin.DAL;

namespace MovieShopDll.Managers
{
    internal class OrderManager : AbstractManager<Order>
    {
        public override List<Order> Read(MovieShopDBContext ctx)
        {
            ctx.SaveChanges();
            return ctx.Orders.Include("Movies").Include("Customer"). ToList();
        }

        public override Order Read(MovieShopDBContext ctx, int id)
        {
            ctx.SaveChanges();
            return ctx.Orders.Include("Movies").FirstOrDefault(x => x.Id == id);
        }

        public override Order Create(MovieShopDBContext ctx, Order t)
        {
            ctx.Orders.Add(t);
            ctx.SaveChanges();
            return t;
        }



        public override bool Delete(MovieShopDBContext ctx, int id)
        {
            Order o = ctx.Orders.FirstOrDefault(x=>x.Id==id);
            ctx.Orders.Remove(o);
            ctx.SaveChanges();
            return true;
        }

        public override Order Update(MovieShopDBContext ctx, Order t)
        {
            throw new NotImplementedException();
        }
    }
}
