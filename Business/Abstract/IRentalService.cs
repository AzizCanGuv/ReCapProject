using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {

        IResult Update(Rental rental);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int id);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();


    }
}
