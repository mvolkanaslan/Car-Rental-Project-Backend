using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileService;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageAddValidator))]
        public IResult Add(CarImageDto carImageDto)
        {
            IResult result = BusinessRules.Run(CarImagesLimitControl(carImageDto.CarId));
            if (result != null) return result;
            CarImage carImage = new CarImage
            {
                CarId = carImageDto.CarId,
                ImagePath = FileOperation.UploadImageFile(carImageDto.ImageFile),
                UploadDate = DateTime.Now
            };
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageUploadSuccess);
        }

        public IResult Delete(CarImage carImage)
        {
           _carImageDal.Delete(carImage);
            FileOperation.DeleteImageFile(carImage.ImagePath);
            return new SuccessResult(Messages.ImageDeleteSuccess);
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ListMsg);
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var _imageList = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (!_imageList.Any())
            {
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> {
                    new CarImage
                    {
                        ImagePath="Upload/Images/CarImages/default.jpg"
                    }
                }, Messages.ListMsg);
            }
            return new SuccessDataResult<List<CarImage>>(_imageList, Messages.ListMsg);
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(ci => ci.Id == id), Messages.ListMsg);
        }

        [ValidationAspect(typeof(CarImageUpdateValidator))]
        public IResult Update(CarImageDto carImageDto)
        {
            var dbImage = _carImageDal.GetById(ci => ci.Id == carImageDto.Id);
            if (dbImage == null) return new ErrorResult(Messages.CarImageNotFound);
            FileOperation.UpdateImageFile(carImageDto.ImageFile, dbImage.ImagePath);
            return new SuccessResult(Messages.ImageUploadSuccess);
        }
        private IResult CarImagesLimitControl(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result < 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ImageLimitError);
        }

    }
}
