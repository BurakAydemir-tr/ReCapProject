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
        IDataResult<List<CarImage>> GetAll();
        IResult Add(IFormFile formFile, CarImage carImage);
        IResult Update(IFormFile formFile, CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<CarImage> Get(CarImage carImage);
        IResult GetList(List<CarImage> list);
        IDataResult<CarImage> FindByID(int Id);

        IDataResult<List<CarImage>> GetCarListByCarID(int carId);

    }
}
