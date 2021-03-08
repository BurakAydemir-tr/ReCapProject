using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IHostingEnvironment _hostingEnvironment;
        //IFormFile _formFile;

        public CarImageManager(ICarImageDal carImageDal, IHostingEnvironment hostingEnvironment)
        {
            _carImageDal = carImageDal;
            _hostingEnvironment = hostingEnvironment;
            //_formFile = formFile;
        }

        public IResult Add(int carId, IFormFile formFile)
        {

            //var result = WriteFile(formFile);
            //CarImage carImage = new CarImage
            //{
            //    CarId = carId,
            //    Date = DateTime.Now,
            //    ImagePath = result,
            //};
            
            //_carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p=>p.CarId==carId));
        }

        //public IDataResult<CarImage> GetById(int imageId)
        //{
        //    return new SuccessDataResult<CarImage>(_carImageDal.Get(p=>p.Id==imageId));
        //}

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }


        //private bool CheckIfImageFile(IFormFile file)
        //{
        //    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
        //    return (extension == ".jpg" || extension == ".png"); // Change the extension based on your need
        //}
        //private async Task<string> WriteFile(IFormFile formFile)
        //{
        //    if (!CheckIfImageFile(formFile))
        //    {
        //        return "Dosya formatı uygun değil";
        //    }


        //    if (Directory.Exists(_hostingEnvironment.WebRootPath + "\\images\\"))
        //    {
        //        Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "\\imagess\\");
        //    }
        //    string FileName = Guid.NewGuid().ToString();
        //    using (FileStream filestream = System.IO.File.Create(_hostingEnvironment.WebRootPath + "\\images\\" + FileName))
        //    {
        //        formFile.CopyTo(filestream);
        //        filestream.Flush();
        //        return FileName;

        //    }
        //}
    }
}
