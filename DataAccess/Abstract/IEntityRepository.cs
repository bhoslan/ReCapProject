using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> //Veriye ulaşım için kullanılacak metotların interface ini oluşturduk.
    {
        List<T> GetAll(Expression <Func<T,bool>> filter=null); //Filtre null da olabilir.
        T Get(Expression<Func<T, bool>> filter);  //Tek bir data için kullanırız.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
