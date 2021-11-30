using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        public void Add(Category category);
        public void Delete(Category category);
        public void Update(Category category);
        List<Category> GetAll();
        List<Category> GetCarsByCategoryId(int CategoryId);
    }
}
