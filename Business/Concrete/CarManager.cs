using Business.Abstract;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new Result(true, "Car added.");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "Car deleted.");
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, "Car updated.");
        }
    }
}
