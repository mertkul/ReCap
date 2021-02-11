using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Car car1 = new Car {BrandId=1,Brand="Honda",ColorId=1,Id=2,DailyPrice=120,Description="Vtec",ModelYear="2020" };
            Car car2 = new Car { BrandId = 2, Brand = "Toyota", ColorId = 3, Id=4, DailyPrice = 150, Description = "VVti", ModelYear = "2021" };
            Brand brand1 = new Brand() { BrandId = 2, BrandName = "Bmw" };
            Color color1 = new Color() { ColorId = 8, ColorName = "Red" };

            List <Car> Cars = new List<Car> { car1, car2 };
            Console.WriteLine("Araçlar");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id, car.ColorId, car.BrandId, car.DailyPrice, car.Description);
            }

            foreach (var cars in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine(car1.Id,car1.Description);
            }
            foreach (var cars2 in carManager.GetAllByColorId(1))
            {
                Console.WriteLine(cars2.ColorId, cars2.Description, cars2.DailyPrice);
            }

            foreach (var details in carManager.GetCarDetails())
            {
                Console.WriteLine(details.Id,details.BrandId,details.BrandName,details.ColorName,details.DailyPrice,details.Description);
            }
            brandManager.Add(new Brand { BrandName = "Mercedes" });
            colorManager.Add(new Color { ColorName = "Blue" });

            
            {

            }
        }
    }
}
