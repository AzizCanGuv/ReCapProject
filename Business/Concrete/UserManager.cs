using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;


namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        [CacheAspect]
        [CacheRemoveAspect("IUserService.Get")]
        [TransactionScopeAspect]
        public IResult Add(User user)
        {
            //Bad Version of validation

            //var context = new ValidationContext<User>(user);
            //UserValidator productValidator = new UserValidator();
            //var result = productValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw FluentValidaton.ValidationException(result.Errors);
            //}
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }
        [TransactionScopeAspect]
        public IDataResult<User> Get(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id), Messages.UserListById);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.ClaimsListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
