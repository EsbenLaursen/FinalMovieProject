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
    internal class CustomerManager : AbstractManager<Customer>
    {
        public override List<Customer> Read(MovieShopDBContext ctx)
        {
            return ctx.Customer.Include("Address").ToList();
        }

        public override Customer Read(MovieShopDBContext ctx, int id)
        {
            return ctx.Customer.Include("Address").FirstOrDefault(x => x.Id == id);
        }

        public override Customer Create(MovieShopDBContext ctx, Customer t)
        {
            ctx.Customer.Add(t);
            ctx.SaveChanges();
            return t;
        }

        public override bool Delete(MovieShopDBContext ctx, int id)
        {
            Customer o = ctx.Customer.FirstOrDefault(x => x.Id == id);
            ctx.Customer.Remove(o);
            ctx.SaveChanges();
            return true;
        }

        public override Customer Update(MovieShopDBContext ctx, Customer c)
        {
            //Check if address is in database

            //bool exists = ctx.Addresses.Any(a => c.Address.StreetName == a.StreetName);
            //if (exists)
            //{
            //    ctx.Entry(c).State = EntityState.Modified;
            //    ctx.SaveChanges();

            //}
            //else
            //{
            //    Address a = c.Address;
            //    ctx.Addresses.Add(a); //This gets added
            //    //Gets the lastest id
            //    int id = ctx.Addresses.Count()+1;
            //    //Now we need to update the reference
            //    ctx.Entry(c.Address).Entity.Id = id; //tHIS DOESNT WORK
            //    ctx.SaveChanges();

            //}

            ctx.Entry(c).State = EntityState.Modified;
            ctx.SaveChanges();
            return c;
        }
    }
}
