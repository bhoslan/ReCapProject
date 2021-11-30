using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService //İş kodlarının yazıldığı bölümdür.
    { 
        ICarDal _carDal; 

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal; //hangi data access layer ile çalışacaksak ona geçiş yapıyoruz.
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId).ToList();
        }

        
        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
