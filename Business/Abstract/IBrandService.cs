using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IBrandService
    {
        public IResult Add(Brand brand);
        public IResult Delete(Brand brand);
        public IResult Update(Brand brand);
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetCarsByBrandId(int id);


    }
}
