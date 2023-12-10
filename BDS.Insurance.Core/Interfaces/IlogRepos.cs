using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.Enums;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Interfaces
{
    public interface IlogRepos
    {
        void Action(string mesage);
        List<Log> GetAllLogs();
        List<Log> GetAllLogsBetweenDate(LogsBetweenDate logsbetweendate);
    }
}
