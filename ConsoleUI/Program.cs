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

            //GetCustomerDto();

            //GetCarDetails();
            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User{ FirstName = "Kemal", LastName = "Gümüş", Email = "k.gumus@gmail.com", Password="0002" });
            //userManager.Delete(new User { FirstName = "Ali", Id=2 });
            //userManager.Update(new User {Id=3, FirstName = "Kemal", LastName = "Gümüş", Email = "k.gumus@gmail.com", Password = "0002" });
            //foreach (var user in userManager.GetAll().Data)
            //{
            //  Console.WriteLine(user.FirstName);
            //}
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental { CarId = 1, CustomerId = 2, Id = 1, RentDate = (new DateTime(2021, 02, 28)), ReturnDate = (new DateTime(2021, 03, 05))});

            //CustomerAdd();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental {CarId=2, CustomerId=2, RentDate= new DateTime(2021,12,7), ReturnDate=new DateTime(2021,12,11)});
           
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 1002, CompanyName = "Company1" });
            customerManager.Delete(new Customer { Id = 1002 });
        }

        private static void GetCustomerDto()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerDto();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CustomerId + " --- " + item.UserId + " --- " + item.UserName + " --- " + item.UserLastName + " --- " + item.EMail);
            }
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetCarDetails().Data)
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
            foreach (var colors in colorManager.GetAll().Data)
            {
                Console.WriteLine(colors.ColorName);
            }
            foreach (var colors in colorManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(colors.ColorName);
            }
        }

        private static void BrandCrudOp()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Jaguar", BrandId = 7});
            brandManager.Delete(new Brand { BrandId = 7 });
            brandManager.Update(new Brand { BrandName = "Jaguar", BrandId = 7 });
            foreach (var brands in brandManager.GetAll().Data)
            {
                Console.WriteLine(brands.BrandName);
            }
            foreach (var brands in brandManager.GetCarsByBrandId(3).Data)
            {
                Console.WriteLine(brands.BrandName);
            }
        }

        private static void CarCrudOp()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car {BrandId = 1, CategoryId = 1, ColorId = 2, DailyPrice = 280, ModelYear = 2021, Description = "Volvo S90" });
            carManager.Delete(new Car { Id = 3002 });
            //carManager.Update(new Car { Id = 5, BrandId = 5, ColorId = 6, CategoryId = 1, DailyPrice = 330, Description = "Audi A6", ModelYear = 2021 });
            //foreach (var item in carManager.GetCarsByColorId(12))
            //{
            //    Console.WriteLine(item.Description);
            //}
            //foreach (var cars in carManager.GetAll())
            //{
            //    Console.WriteLine(cars.Description);
            //}
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
            Console.WriteLine(carManager.GetCarsByBrandId(1));
        }
    }
}
