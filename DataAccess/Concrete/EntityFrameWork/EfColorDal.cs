using Core.DataAccess.EntityFrameWork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarContext>, IColorDal
    {
       
    }
}
