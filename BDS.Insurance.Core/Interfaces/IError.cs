using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Interfaces
{
    public interface IError
    {
        List<Error> GetAllError();
        List<Error> GetAllErrorsBetweenDate(ErrorsBetweenDate errorsBetweenDate);
    }
}
