using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDatabase>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDatabase context = new ReCapProjectDatabase())
            {
                var result = from cr in context.Cars
                    
                    join br in context.Brands on cr.BrandId equals br.Id
                    
                    join clr in context.Colors on cr.ColorId equals clr.Id

                    select new CarDetailDto
                    {
                        CarId = cr.Id,
                        BrandName = br.Name,
                        ColorName = clr.Name,
                        DailyPrice = cr.DailyPrice,
                        ModelYear = cr.ModelYear,
                        Description = cr.Description
                    };

                return result.ToList();


            }
            

        }
    }
}
