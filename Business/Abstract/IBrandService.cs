using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IBrandService
    {
        public void Add(Brand brand);
        public void Delete(Brand brand);
        public void Update(Brand brand);
        List<Brand> GetAll();
        List<Brand> GetCarsByBrandId(int id);


    }
}
