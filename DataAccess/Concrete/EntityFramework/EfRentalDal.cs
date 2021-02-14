using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDatabase>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectDatabase context = new ReCapProjectDatabase())
            {
                var result = from rnt in context.Rentals
                    join cu in context.Customers on rnt.CustomerId equals cu.id
                    join nme in context.Brands on rnt.CarId equals nme.Id
                    join usr in context.Users on cu.UserId equals usr.Id

                             select new RentalDetailDto 
                             {
                                 RentalId = rnt.Id,
                                 CustomerName = cu.CompanyName,
                                 CarName = nme.Name,
                                 UserName = "Name= " + usr.FirstName + " Surname= " + usr.LastName,
                                 RentDate = rnt.RentDate,
                                 ReturnDate = rnt.ReturnDate
                             }; 
                return result.ToList();
            }

        }
    }
}
