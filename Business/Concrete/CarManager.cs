﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            // Şeklinde validation yapılabilir 
            //ValidationTool.Validate(new CarValidator(),car);
            
            
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Delete(Car car)
        {
            
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<Car> Get(int id)
        {
            

            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id), Messages.CarGet );
        }

        public IDataResult<List<Car>> GetAll()
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.AllCarList);
        }

        public IResult Update(Car car)
        {
            
            
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id), Messages.CarsListedByColor);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id), Messages.CarsListedByBrand);
            
        }
    }
}
