using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Services
{
    public class UserService:IUser
    {
        private readonly IUserRepos userrepos;
        public UserService(IUserRepos userrepos)
        {
            this.userrepos = userrepos;
        }
        public bool InsertUser(InsertUser insertUser)
        {
            return userrepos.InsertUser(insertUser);
        }

    }
}
