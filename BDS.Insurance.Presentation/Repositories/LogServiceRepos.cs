using BDS.Insurance.Core.DBContexti;
using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Presentation.Repositories
{
    public class LogServiceRepos:IlogRepos
    {
        private readonly DbBds dbbds;
        public LogServiceRepos(DbBds dbbds)
        {
            this.dbbds = dbbds;
        }

        #region Action
        public void Action(string mesage)
        {
            if (mesage != null)
            {
                dbbds.Logs.Add(new Log()
                {
                    TimeofOccured = DateTime.Now,
                    Text = mesage
                });
                dbbds.SaveChanges();
            }
        }
        #endregion

        #region GetAllLogs
        public List<Log> GetAllLogs()
        {
           return dbbds.Logs.ToList();
        }
        #endregion

        #region GetAllLogsBetweenDate
        public List<Log> GetAllLogsBetweenDate(LogsBetweenDate logsbetweendate)
        {
           return dbbds.Logs.Where(i=>i.TimeofOccured>=logsbetweendate.StartDate&&i.TimeofOccured<=logsbetweendate.EndDate).ToList();
        }
        #endregion


    }
}
