using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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
            _carDal = carDal;
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

        public void Add(Car car)
        {
            if (car.Description.Length <2 || car.DailyPrice <= 0)
            {
                Console.WriteLine("Araç ismini veya günlük fiyatı yanlış girdiniz.");
            }
            else
            {
                _carDal.Add(car);
            }
        }
    }
}
