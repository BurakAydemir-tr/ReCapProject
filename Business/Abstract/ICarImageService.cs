using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll(int carId);
        IResult Add(int carId, IFormFile formFile);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage);
        //IDataResult<CarImage> GetById(int imageId);
    }
}
