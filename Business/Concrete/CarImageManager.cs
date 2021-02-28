using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

           [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile,CarImage carImage)
        {
            
            //Kurallar gelecek
            var result =  BusinessRules.Run(ImageCapacityExceed(carImage.Id));
            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            carImage.ImagePath = FileHelper.Add(formFile);
            _carImageDal.Add(carImage);


            return new SuccessResult(Messages.ImageIsAdded);



        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete( CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath); 
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageIsDeleted);

        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.AllTheCarImagesListed);
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<List<CarImage>> GetCarImagesById(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfImageNull(id));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == carImage.Id).ImagePath, formFile);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();

        }

        private List<CarImage> CheckIfImageNull(int id)
        {
            var result = _carImageDal.GetAll(p => p.Id == id).Any();
            string defaultPath = @"\Images\default.jpg";
            if (result)
            {
                
                return new List<CarImage>{new CarImage{ CarId = id, Date =  DateTime.Now,ImagePath = defaultPath}};
            }
            return _carImageDal.GetAll(p => p.ImagePath == defaultPath);
        }
        

        private IResult ImageCapacityExceed(int id)
        {
            var result= _carImageDal.GetAll(p => p.Id == id).Count;
            
            if (result >= 5)
            {
                return new ErrorResult(Messages.ImageCapacityExceed);
            }

            return new SuccessResult();

        }

    }
}
