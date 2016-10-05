using MovieShopDll.Entities;
using MyMovieShopAdmin.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDll.Managers
{
    internal abstract class AbstractManager<T> : IManager<T> where T : AbstractEntity
    {
        private static int _id = 1;

        public List<T> Read()
        {
            using (var ctx = new MovieShopDBContext())
            {
                return Read(ctx);  
            }
        }

        public abstract List<T> Read(MovieShopDBContext ctx);

        public T Read(int id)
        {
            using (var ctx = new MovieShopDBContext())
            {
                return Read(ctx, id);
            }
        }
        public abstract T Read(MovieShopDBContext ctx, int id);


        public T Create(T t)
        {
            using (var ctx = new MovieShopDBContext())
            {
                return Create(ctx, t);
            }
        }
        public abstract T Create(MovieShopDBContext ctx, T t);
        

        public T Update(T newObject)
        {
            using (var ctx = new MovieShopDBContext())
            {
                return Update(ctx, newObject);
            }
        }
        public abstract T Update(MovieShopDBContext ctx, T t);

        public bool Delete(int id)
        {
            using (var ctx = new MovieShopDBContext()) {
                return Delete(ctx, id); }
           
        }
        public abstract bool Delete(MovieShopDBContext ctx, int id);


    }
}
