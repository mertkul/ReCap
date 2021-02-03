using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //Global 
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car{Id=1,BrandId=1,ColorId=3,Brand="Honda",DailyPrice="150",ModelYear="2021",Description="Civic Vtec"},
                new Car{Id=2,BrandId=2,ColorId=5,Brand="Toyota",DailyPrice="150",ModelYear="2020",Description="Hybrid"},
                new Car{Id=3,BrandId=4,ColorId=7,Brand="Bmw",DailyPrice="200",ModelYear="2021",Description="m5"},
                new Car{Id=4,BrandId=8,ColorId=9,Brand="Mercedes",DailyPrice="250",ModelYear="2020",Description="Kompressor 4 Matic"},
                new Car{Id=5,BrandId=5,ColorId=11,Brand="Audi",DailyPrice="300",ModelYear="2021",Description="Tfsi Quatro"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
          //Lambda .. Linq
          Car carToDelete = _cars.SingleOrDefault(c=>c.Id ==car.Id);
          _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int BrandId)
        {
            //where : İçinde ki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Brand = car.Brand;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
