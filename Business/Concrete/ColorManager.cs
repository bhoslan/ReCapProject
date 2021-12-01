using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using Core.Utilities.Results;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color );
            return new Result(true, "Color added.");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new Result(true, "Color deleted.");
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(true, "Color updated.");
        }
        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Color> GetCarsByColorId(int ColorId)
        {
            return _colorDal.GetAll(c => c.ColorId == ColorId);
        }

        
    }

    
}
