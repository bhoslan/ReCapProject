using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using DataAccess.Abstract; 

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            _colorDal.Add(color );
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
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
