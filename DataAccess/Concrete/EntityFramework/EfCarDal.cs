using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapCarContext context=new ReCapCarContext())
            {
                var result = from c in filter==null? context.Cars:context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             //join i in context.CarImages
                             //on c.Id equals i.CarId
                             select new CarDetailDto 
                             { 
                                 Id = c.Id, 
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description,
                                 Status = !(context.Rentals.Any(p => p.CarId==c.Id && (p.ReturnDate == null || p.ReturnDate>DateTime.Now))),
                                 ImagePath=context.CarImages.Where(p=>p.CarId==c.Id).FirstOrDefault().ImagePath
                             };
                return result.ToList();
            }
        }
    }
}
