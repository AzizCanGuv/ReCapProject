using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Migrations.Operations;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDatabase>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectDatabase context = new ReCapProjectDatabase())
            {

                var result = from rent in context.Rentals
                    join car in context.Cars
                        on rent.CarId equals car.Id
                    join brand in context.Brands
                        on car.BrandId equals brand.Id
                    join customer in context.Customers
                        on rent.CustomerId equals customer.id
                    join user in context.Users
                        on customer.UserId equals user.Id
                    select new RentalDetailDto
                    {
                        RentalId = rent.Id,
                        CarName = brand.Name,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        RentDate = rent.RentDate,
                        ReturnDate = rent.ReturnDate
                    };
                return result.ToList();
                /*
            var result = from rnt in context.Rentals

                join cu in context.Customers on rnt.CustomerId equals cu.id

                join nme in context.Brands on rnt.CarId equals nme.Id

                join usr in context.Users on cu.UserId equals usr.Id

                         select new RentalDetailDto 
                         {
                             RentalId = rnt.Id,
                             CarName = nme.Name,
                             FirstName = usr.FirstName,
                             LastName = usr.LastName,
                             CustomerName = cu.CompanyName,
                             RentDate = rnt.RentDate,
                             ReturnDate = rnt.ReturnDate
                         }; 
            return result.ToList();
                */

            }

        }
    }
}
