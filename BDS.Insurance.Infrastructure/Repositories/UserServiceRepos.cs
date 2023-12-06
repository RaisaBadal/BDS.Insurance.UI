using BDS.Insurance.Core.DBContexti;
using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Infrastructure.Repositories
{
    public class UserServiceRepos:IUserRepos
    {
        private readonly DbBds dbBds;
        public UserServiceRepos(DbBds dbBds)
        {
            this.dbBds = dbBds;
        }

        public bool InsertUser(InsertUser insertUser)
        {
            using (var trans = dbBds.Database.BeginTransaction())
            {
                try
                {
                    var ag = age(insertUser.BirthDate);
                    if (ag == false)
                    {
                        return false;
                    }
                    else
                    {
                        var userreg = new User
                        {
                            FirstName = insertUser.FirstName,
                            LastName = insertUser.LastName,
                            PersonalNumber = insertUser.PersonalNumber,
                            BirthDate = insertUser.BirthDate,
                            TelNumber = insertUser.TelNumber,
                            Email = insertUser.Email,
                            Address = insertUser.Address
                        };
                        var users = dbBds.Users.Where(i => i.Email == insertUser.Email || i.PersonalNumber == insertUser.PersonalNumber).FirstOrDefault();
                        if (users == null)
                        {
                            dbBds.Users.Add(userreg);
                            dbBds.SaveChanges();
                            trans.Commit();
                            return true;
                        }
                        else
                        {
                            trans.Rollback();
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public bool age(DateTime birthdate)
        {
            DateTime date = DateTime.Today;
            if ((date.Year - birthdate.Year) >= 18)
            {
                return true;
            }
            else return false;
        }
    }
}
