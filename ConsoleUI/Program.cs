using Business.Concrete;
using DataAccess.Concrete.InMemory;
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
                Console.WriteLine("Araç Markası: "+car.Brand);
                Console.WriteLine("Açıklama: "+ car.Description);
                Console.WriteLine("Günlük kiralama bedeli:" + car.DailyPrice);
                Console.WriteLine("--------------------");
                

            }
            
        }
    }
}
