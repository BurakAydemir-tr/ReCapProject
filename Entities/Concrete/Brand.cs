using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        private string _brandName;

        public int Id { get; set; }
        public string BrandName
        {
            get { return _brandName; }
            set
            {
                if (value.Length<2)
                {
                    throw new Exception("Arabanın marka ismi iki karakterden küçük olamaz.");
                }
                else
                {
                    _brandName = value;
                }
            }

        }
    }
}
