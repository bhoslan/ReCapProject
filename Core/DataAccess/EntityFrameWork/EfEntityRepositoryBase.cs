using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Core.DataAccess.EntityFrameWork
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext()) //Kullanıldıktan sonra hemen garbage collector a using sayesinde gider.
            {
                var addedEntity = context.Entry(entity); //Eklenecek aracın referansı alındı
                addedEntity.State = EntityState.Added; //Araç eklendi.
                context.SaveChanges(); //using bloğunda yapılanları kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null //Filtre null mı?
                    ? context.Set<TEntity>().ToList() //Evetse bunu yap.
                    : context.Set<TEntity>().Where(filter).ToList(); //Hayırsa bunu yap.
            }
        }
    }
}
