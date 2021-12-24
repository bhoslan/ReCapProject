using Business.Abstract;
using System.IO;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Business.Constants;
using Core.Utilities.Helpers;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _ImageDal;

        public CarImageManager(ICarImageDal ImageDal)
        {
            _ImageDal = ImageDal;
        }

        static string directory = Directory.GetCurrentDirectory() + @"\wwwroot\";
        static string path = @"Images\"; //içerisindeki özel karakterler alınmasın diye @ koyduk
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckImageCount(carImage), CheckImageExtensionValid(file));

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _ImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult AddCollective(IFormFile[] files, CarImage carImage)
        {
            foreach (var file in files)
            {
                carImage = new CarImage { CarID = carImage.CarID };
                Add(file, carImage);
            }
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            string oldPath = GetById(carImage.ImageID).Data.ImagePath;
            FileHelper.Delete(oldPath);
            _ImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_ImageDal.GetAll(), Messages.ImagesListed);
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_ImageDal.Get(i => i.CarID == imageId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _ImageDal.GetAll(i => i.CarID == carId);

            if (result.Count >0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            List<CarImage> images = new List<CarImage>();
            images.Add(new CarImage() { CarID = 0, ImageID = 0, Date = DateTime.Now, ImagePath = "images/unnamed.png" });

            return new SuccessDataResult<List<CarImage>>(images);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckImageExtensionValid(file));
            if (result!=null)
            {
                return result;
            }

            CarImage oldCarImage = GetById(carImage.CarID).Data;
            carImage.ImagePath = FileHelper.Update(file, oldCarImage.ImagePath);
            carImage.Date = DateTime.Now;
            carImage.CarID = oldCarImage.CarID;
            _ImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);


        }
        private IResult CheckImageCount(CarImage carImage)
        {
            var result = _ImageDal.GetAll(i => i.CarID == carImage.CarID).Count;
            if (result > 5)
            {
                new ErrorResult(Messages.FailedCarImageAdd);
            }
            return new SuccessResult();
        }
        private IResult CheckImageExtensionValid(IFormFile file)
        {
            string[] validImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".GIF", ".TIFF", ".TIF", ".BMP", ".ICO", ".WEBP" };
            var result = validImageFileTypes.Any(t=>t == Path.GetExtension(file.FileName).ToUpper());
            if (!result)
            {
                return new ErrorResult("Geçersiz uzantı");
            }
            return new SuccessResult();
        }
    }

}
