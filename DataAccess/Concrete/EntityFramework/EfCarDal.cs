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
                    join br in context.Brands
                        on cr.BrandId equals br.Id
                    join co in context.Colors
                        on cr.ColorId equals co.Id
                    select new CarDetailDto
                    {
                        CarName = cr.Id.ToString(),
                        BrandName = br.Name,
                        DailyPrice = cr.DailyPrice,
                        ColorName = co.Name
                    };

                return result.ToList();
            }
            

        }
    }
}
