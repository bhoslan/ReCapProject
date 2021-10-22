using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.Inmemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ModelYear=2015,Description="Volvo V40",ColorId=1,DailyPrice=220,CategoryId=11},
                new Car{Id=2,BrandId=2,ModelYear=2014,Description="Opel Astra",ColorId=2,DailyPrice=180,CategoryId=21},
                new Car{Id=3,BrandId=3,ModelYear=2011,Description="Ford Fiesta",ColorId=12,DailyPrice=140,CategoryId=31},
                new Car{Id=4,BrandId=5,ModelYear=2019,Description="Mercedes",ColorId=9,DailyPrice=310,CategoryId=41},
                new Car{Id=5,BrandId=7,ModelYear=2020,Description="Audi",ColorId=7,DailyPrice=280,CategoryId=51},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p=>p.Id ==car.Id); //Linq ile silinecek aracın id sini bulduk.
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int categoryId)
        {
            return _cars.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
