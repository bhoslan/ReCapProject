using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        public void Add(Color color);
        public void Delete(Color color);
        public void Update(Color color);
        List<Color> GetAll();
        List<Color> GetCarsByColorId(int ColorId);
    }
}
