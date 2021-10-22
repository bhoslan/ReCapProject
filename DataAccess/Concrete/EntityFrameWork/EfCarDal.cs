using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarContext context = new CarContext()) //Kullanıldıktan sonra hemen garbage collector a using sayesinde gider.
            {
                var addedEntity = context.Entry(entity); //Eklenecek aracın referansı alındı
                addedEntity.State = EntityState.Added; //Araç eklendi.
                context.SaveChanges(); //using bloğunda yapılanları kaydet
            }
        }

        public void Delete(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
            
        }

        public void Update(Car entity)
        {
            using (CarContext context = new CarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarContext context = new CarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                return filter == null //Filtre null mı?
                    ? context.Set<Car>().ToList() //Evetse bunu yap.
                    : context.Set<Car>().Where(filter).ToList(); //Hayırsa bunu yap.
            }
        }

        
    }
}
