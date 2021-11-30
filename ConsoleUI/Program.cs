using Business.Concrete;
using Core.DataAccess;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Previous();

            //CarCrudOp();

            //BrandCrudOp();

            //ColorCrudOp();

            //GetCarDetails();
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetCarDetails())
            {
                Console.WriteLine(cars.CarName + " --- " + cars.BrandName + " --- " + cars.ColorName + " --- " + cars.DailyPrice);
            }
        }

        private static void ColorCrudOp()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 3, ColorName = "Dark Grey" });
            colorManager.Delete(new Color { ColorId = 12 });
            colorManager.Update(new Color { ColorId = 9, ColorName = "Blue" });
            foreach (var colors in colorManager.GetAll())
            {
                Console.WriteLine(colors.ColorName);
            }
            foreach (var colors in colorManager.GetCarsByColorId(1))
            {
                Console.WriteLine(colors.ColorName);
            }
        }

        private static void BrandCrudOp()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Toyota", BrandId = 7 });
            brandManager.Delete(new Brand { BrandId = 7 });
            brandManager.Update(new Brand { BrandName = "Jaguar", BrandId = 7 });
            foreach (var brands in brandManager.GetAll())
            {
                Console.WriteLine(brands.BrandName);
            }
            foreach (var brands in brandManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(brands.BrandName);
            }
        }

        private static void CarCrudOp()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 5, CategoryId = 1, ColorId = 6, DailyPrice = 195, ModelYear = 2021, Description = "Audi A6" });
            carManager.Delete(new Car { Id = 2007 });
            carManager.Update(new Car { Id = 4, BrandId = 4, ColorId = 9, CategoryId = 1, DailyPrice = 330, Description = "Mercedes C200", ModelYear = 2020 });
            foreach (var item in carManager.GetCarsByColorId(12))
            {
                Console.WriteLine(item.Description);
            }
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
        }

        private static void Previous()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 3,
                CategoryId = 5,
                ColorId = 7,
                DailyPrice = 180,
                Description = "Renault Megane 5",
                ModelYear = 2019
            });
            Console.WriteLine(carManager.GetCarsByBrandId(1).ToList());
        }
    }
}
