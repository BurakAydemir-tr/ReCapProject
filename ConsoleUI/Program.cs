using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            carManager.Add(new Car {Id=6, BrandId=4, ColorId=7, DailyPrice=350000, ModelYear=2015, Description="Mercedes CLA" });
            Car carSearch = carManager.GetById(6);
            Console.WriteLine(carSearch.Description);

            carManager.Delete(new Car { Id = 4, BrandId = 2, ColorId = 5, DailyPrice = 120000, ModelYear = 2017, Description = "Avensis" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.ReadLine();
            //Console.WriteLine("Hello World!");
        }
    }
}
