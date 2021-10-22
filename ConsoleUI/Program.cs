using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.Concrete.Inmemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var p in carManager.GetCarsByColorId(9))
            {
                Console.WriteLine(p.Description);
            }

            Car Peugeout = new Car();
            Peugeout.BrandId = 1;
            Peugeout.CategoryId = 2;
            Peugeout.ColorId = 2;
            Peugeout.Description = "Al";
            Peugeout.DailyPrice = 0;
            carManager.Add(Peugeout);

        }
    }
}
