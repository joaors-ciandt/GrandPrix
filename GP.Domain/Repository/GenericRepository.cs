using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomFramework.Security.Membership.Model;
using GP.Domain.Repository.Context;

namespace GP.Domain.Repository
{
    public class GenericRepository<T> where T : ModelBase
    {

        GPContext context = new GPContext();

        public void Create(T model)
        {
            context.Set<T>().Add(model);
            context.SaveChanges();
        }

        public void Update(T model)
        {
            context.Set<T>().Attach(model);
            context.Entry<T>(model).State = System.Data.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T model)
        {
            context.Set<T>().Attach(model);
            context.Set<T>().Remove(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            T model = Find(id);
            context.Set<T>().Remove(model);
            context.SaveChanges();
        }

        public T Find(Func<T, bool> predicate)
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public T Find(int id)
        {
            return context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public List<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public List<T> FindAll(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public List<T> SlicedFindAll(int start, int length)
        {
            return context.Set<T>().Skip(start).Take(length).ToList();
        }

        public List<T> SlicedFindAll(Func<T, bool> predicate, int start, int length)
        {
            return context.Set<T>().Where(predicate).Skip(start).Take(length).ToList();
        }

    }
}
