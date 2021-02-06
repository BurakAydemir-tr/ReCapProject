using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}

            carManager.Add(new Car {Id=6, BrandId=2, ColorId=3, DailyPrice=300000, ModelYear=2013, Description="GrandLandx" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }


            Console.ReadLine();
            //Console.WriteLine("Hello World!");
        }
    }
}
