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
    public class UserService:IUser
    {
        private readonly IUserRepos userrepos;
        public UserService(IUserRepos userrepos)
        {
            this.userrepos = userrepos;
        }

        public List<User> GetAllUser()
        {
           return userrepos.GetAllUser();
        }

        public GetUserByIdResponce GetUserById(UserID userid)
        {
            return userrepos.GetUserById(userid);
        }

        public bool InsertUser(InsertUser insertUser)
        {
            return userrepos.InsertUser(insertUser);
        }

        public bool SignIn(UserSignIn usersignIn)
        {
            return userrepos.SignIn(usersignIn);
        }

        public string Verification(VerificationRequest verRequest)
        {
            return userrepos.Verification(verRequest);
        }
    }
}
