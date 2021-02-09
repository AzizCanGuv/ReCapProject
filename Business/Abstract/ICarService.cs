using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();

        Car Get(int id);
        void Update(Car car);
        void Delete(Car car);
        void Add(Car car);
        List<CarDetailDto> GetCarDetails();

    }
}
