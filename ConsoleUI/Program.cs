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
            ShowCarData();
            Console.WriteLine();
            ShowBrandData();
            Console.WriteLine();
            ShowColorData();
        }

        public static void ShowCarData()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "   " + car.BrandName + "   " + car.DailyPrice + "   " + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }


        public static void ShowBrandData()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());



            ;

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Id + "    " + brand.Name);
            }
        }

        public static void ShowColorData()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());


            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Id + "    " + color.Name);
            }

        }
    }
}
