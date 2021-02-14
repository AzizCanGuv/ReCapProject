﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Update(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> Get(int id);
        


    }
}