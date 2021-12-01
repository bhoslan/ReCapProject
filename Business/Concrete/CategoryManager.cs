using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new Result(true, "Category added.");
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new Result(true, "Category deleted.");
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetCarsByCategoryId(int categoryId)
        {
            return _categoryDal.GetAll(c => c.CategoryId == categoryId);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new Result(true, "Category updated.");
        }
    }
}
