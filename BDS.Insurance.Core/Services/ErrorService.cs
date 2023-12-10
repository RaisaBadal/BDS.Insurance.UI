using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Services
{
    public class ErrorService:IError
    {
        private readonly IErrorRepos errorrepos;
        public ErrorService(IErrorRepos errorrepos)
        {
            this.errorrepos = errorrepos;
        }

        public List<Error> GetAllError()
        {
           return errorrepos.GetAllError();
        }

        public List<Error> GetAllErrorsBetweenDate(ErrorsBetweenDate errorsBetweenDate)
        {
            return errorrepos.GetAllErrorsBetweenDate(errorsBetweenDate);
        }
    }
}
