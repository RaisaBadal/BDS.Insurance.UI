using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Interfaces
{
    public interface IUserRepos
    {
        bool InsertUser(InsertUser insertUser);
        bool SignIn(UserSignIn usersignIn);
        string Verification(VerificationRequest verRequest);
        List<User>GetAllUser();
        GetUserByIdResponce GetUserById(UserID userid);

    }
}
