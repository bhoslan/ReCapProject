using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        public IResult Add(Category category);
        public IResult Delete(Category category);
        public IResult Update(Category category);
        IDataResult<List<Category>> GetAll();
        IDataResult<List<Category>> GetCarsByCategoryId(int CategoryId);
    }
}
