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
    internal class OrderManager : AbstractManager<Order>
    {
        public override List<Order> Read(MovieShopDBContext ctx)
        {
            return ctx.Orders.Include("Movies").Include("Customer"). ToList();
        }

        public override Order Read(MovieShopDBContext ctx, int id)
        {
            return ctx.Orders.Include("Movies").Include("Customer").FirstOrDefault(x => x.Id == id);
        }

        public override Order Create(MovieShopDBContext ctx, Order t)
        {
            ctx.Entry(t.Customer).State = EntityState.Unchanged;
            ctx.Orders.Add(t);
            ctx.SaveChanges();
            return t;
        }



        public override bool Delete(MovieShopDBContext ctx, int id)
        {
            Order o = ctx.Orders.FirstOrDefault(x=>x.Id==id);
            ctx.Entry(o).State = EntityState.Deleted;
            return true;
        }

        public override Order Update(MovieShopDBContext ctx, Order t)
        {
            ctx.Entry(t).State = EntityState.Modified;
            return t;
        }
    }
}
