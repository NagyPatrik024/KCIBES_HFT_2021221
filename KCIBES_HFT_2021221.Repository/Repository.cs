using KCIBES_HFT_2021221.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCIBES_HFT_2021221.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected F1DbContext _ctx;

        public Repository(F1DbContext ctx)
        {
            this._ctx = ctx;
        }

        public abstract void CreateOne(T item);

        public abstract void DeleteOne(int id);

        public IQueryable<T> GetAll()
        {
            return _ctx.Set<T>();
        }

        public abstract T GetOne(int id);

        public abstract void UpdateOne(int id, T item);
    }
}
