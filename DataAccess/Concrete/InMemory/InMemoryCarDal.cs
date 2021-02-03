using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car
                {
                    Id = 1, BrandId = "Mercedes", ColorId = "Black", DailyPrice = 1000, ModelYear = 2021,
                    Description = " E200 D"
                },
                new Car
                {
                    Id = 2, BrandId = "BMW", ColorId = "Red", DailyPrice = 500, ModelYear = 2018, Description = " 420i"
                },
                new Car
                {
                    Id = 3, BrandId = "Lamborghini", ColorId = "Yellow", DailyPrice = 10000, ModelYear = 2015,
                    Description = " Aventador"
                },
                new Car
                {
                    Id = 4, BrandId = "Porsche", ColorId = "Green", DailyPrice = 5000, ModelYear = 2019,
                    Description = " 911 Turbo S"
                }




            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car _carToDelete;

            _carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);

            _cars.Remove(_carToDelete);

        }

        public List<Car> GetAll()
        {
            return _cars;

        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car _carToUpdate;

            _carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            car.Id = _carToUpdate.Id;
            car.BrandId = _carToUpdate.BrandId;
            car.ColorId = _carToUpdate.ColorId;
            car.DailyPrice = _carToUpdate.DailyPrice;
            car.Description = _carToUpdate.Description;
            car.ModelYear = _carToUpdate.ModelYear;


        }
    }
}
