using BDS.Insurance.Core.DBContexti;
using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.Enums;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Presentation.Repositories
{
    public class ErrorServiceRepos:IErrorRepos
    {
        private readonly DbBds dbbds;
        public ErrorServiceRepos(DbBds dbbds)
        {
                this.dbbds = dbbds;
        }

        #region Action
        public void Action(string mesage, ErrorTypeEnum type)
        {
            //funqcia romelic chawers bazashi ra errori moxda
            if (mesage != null)
            {
                dbbds.Errors.Add(new Error()
                {
                    ErrorType = type,
                    TimeofOccured = DateTime.Now,
                    Text = mesage
                });
                dbbds.SaveChanges();
            }
        }
        #endregion

        #region GetAllError

        public List<Error> GetAllError()
        {
            return dbbds.Errors.ToList();
        }

        #endregion

        #region GetAllErrorsBetweenDate
        public List<Error> GetAllErrorsBetweenDate(ErrorsBetweenDate errorsBetweenDate)
        {
            return dbbds.Errors.Where(i=>i.TimeofOccured>= errorsBetweenDate.StartDate&&i.TimeofOccured<= errorsBetweenDate.EndDate).ToList();
        }
        #endregion

    }
}
