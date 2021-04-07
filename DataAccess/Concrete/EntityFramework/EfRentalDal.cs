using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapCarContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapCarContext context = new ReCapCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cus in context.Customers
                             on r.CustomerId equals cus.CustomerId
                             join u in context.Users
                             on cus.UserId equals u.UserId
                             select new RentalDetailDto
                             { 
                                RentalId=r.RentalId,
                                BrandName=b.BrandName,
                                CarName=c.CarName,
                                FirstName=u.FirstName,
                                LastName=u.LastName
                             };
                return result.ToList();
            }
        }
    }
}
