﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;


namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Update(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> Get(int id);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);



    }
}
