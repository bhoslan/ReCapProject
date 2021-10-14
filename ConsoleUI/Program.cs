using Business.Concrete;
using DataAccess.Concrete.Inmemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var p in carManager.GetAll())
            {
                Console.WriteLine(p.Description);
            }
        }
    }
}
