using System;
using System.Security.Cryptography.X509Certificates;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());




            

            

            
            // Added carManager.Add(new Car{Id = 10, BrandId ="Opel Corsa" ,ColorId ="Beyaz" ,DailyPrice =100 ,ModelYear =2015 ,Description ="Manuel vites Arka bagaj boyalı" });
            // Added carManager.Add(new Car { Id = 11, BrandId = "Toyota Corolla", ColorId = "Koyu yeşil", DailyPrice =125 , ModelYear = 2020, Description = "Otomatik vites Kazasız" });
            //ShowData();

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "   " + car.BrandName + "   " + car.DailyPrice + "   " + car.ColorName);
            }

        }

        public static void ShowData()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId+ "  " + car.ColorId + "  " + car.ModelYear + "  " + car.DailyPrice + "  " +
                                  car.Description);
            }
        }
    }
}
