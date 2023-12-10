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
    public class LogService:ILog
    {
        private readonly IlogRepos logrepos;
        public LogService(IlogRepos logrepos)
        {
            this.logrepos = logrepos;
        }

        public List<Log> GetAllLogs()
        {
           return logrepos.GetAllLogs();
        }

        public List<Log> GetAllLogsBetweenDate(LogsBetweenDate logsbetweendate)
        {
            return logrepos.GetAllLogsBetweenDate(logsbetweendate);
        }
    }
}
