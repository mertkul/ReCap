using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araç başarıyla eklendi");
            }
            else
            {
                Console.WriteLine("Günlük ücreti 0'dan büyük giriniz.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araç başarıyla silindi.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(car => car.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(car => car.ColorId == id);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(car => car.DailyPrice >= min && car.DailyPrice <= max);
        }

        public Car GetById(int id)
        {
            return _carDal.Get(car => car.Id == id);
        }

        public List<Car> GetByModelYear(string year)
        {
            return _carDal.GetAll(car => car.ModelYear.Contains(year) == true);
        }

        public void Update(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Update(car);
                Console.WriteLine("Araç başarıyla güncellendi");
            }
            else
            {
                Console.WriteLine("Lütfen !!! Günlük kiralama beledini 0 ' dan büyük girin.");
            }
        }
    }
}
