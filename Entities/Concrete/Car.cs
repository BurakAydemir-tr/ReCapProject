using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        private double _dailyPrice;

        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice
        {
            get { return _dailyPrice; }
            set
            {
                if (value<=0)
                {
                    throw new Exception("Arabanın günlük fiyatı sıfırdan küçük olamaz.");
                }else
                {
                    _dailyPrice = value;
                }
            }
        }
        public string Description { get; set; }
    }
}
