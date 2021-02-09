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
            //CarUpdate();
            //CarAdd();
            //CarDelete();
            //CarGetAll();
            //CarGetbyId();

            //BrandAdd();
            //BrandUpdate();
            //BrandDelete();
            //BrandGetbyId();

            //ColorAdd();
            //ColorUpdate();
            //ColorDelete();
            //ColorGetbyId();

            GetCarDetails();
            Console.ReadLine();
            //Console.WriteLine("Hello World!");
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0}-{1}-{2}-{3}",car.CarName,car.BrandName,car.ColorName,car.DailyPrice);
            }
        }

        private static void ColorGetbyId()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(colorManager.GetById(3).ColorName);
        }

        private static void BrandGetbyId()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandManager.GetById(2).BrandName);
        }

        private static void CarGetbyId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetById(1).Description);
        }

        private static void ColorDelete()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color { ColorId = 4, ColorName = "Yeşil" });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void ColorUpdate()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { ColorId = 4, ColorName = "Yeşil" });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorId = 4, ColorName = "Kırmızı" });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandDelete()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Delete(new Brand { BrandId = 4, BrandName = "Ford" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void BrandUpdate()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Update(new Brand { BrandId = 4, BrandName = "Ford" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            brandManager.Add(new Brand { BrandId = 4, BrandName = "Honda" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarGetAll(CarManager _carManager)
        {
            foreach (var car in _carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 6, BrandId = 2, ColorId = 3, DailyPrice = 300000, ModelYear = 2013, Description = "CrossLandX" });

            CarGetAll(carManager);
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 6, BrandId = 2, ColorId = 3, DailyPrice = 300000, ModelYear = 2013, Description = "CrossLandX" });

            CarGetAll(carManager);
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Id = 7, BrandId = 3, ColorId = 3, DailyPrice = 300000, ModelYear = 2013, Description = "Auris" });


            CarGetAll(carManager);
        }
    }
}
