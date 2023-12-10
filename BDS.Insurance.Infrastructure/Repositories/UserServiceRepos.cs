using BDS.Insurance.Core.DBContexti;
using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using BDS.Insurance.DataSource.Email;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using BDS.Insurance.DataSource.Enums;

namespace BDS.Insurance.Infrastructure.Repositories
{
    public class UserServiceRepos:IUserRepos
    {
        private readonly DbBds dbBds;
        private readonly IErrorRepos errorrepos;
        private readonly IlogRepos logrepos;
        public UserServiceRepos(DbBds dbBds, IErrorRepos errorrepos, IlogRepos logrepos)
        {
            this.dbBds = dbBds;
            this.errorrepos = errorrepos;
            this.logrepos = logrepos;
        }

        #region InsertUser

        public bool InsertUser(InsertUser insertUser)
        {
            using (var trans = dbBds.Database.BeginTransaction())
            {
                try
                {
                    var ag = age(insertUser.BirthDate);
                    if (ag == false)
                    {
                        errorrepos.Action($"Asaki naklebia 18 welse, piradi nomeri: {insertUser.PersonalNumber}", ErrorTypeEnum.Warning);
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
                            logrepos.Action($"Warmatebit daemata iuzeri, id:{userreg.Id}");
                            trans.Commit();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    errorrepos.Action(ex.Message,ErrorTypeEnum.Fatal);
                    throw ex;
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

        #endregion

        #region GeneretaJwt

        private string GeneretaJwt(User user)
        {
            if (user == null)
            {
                return null;
            }

            var claims = new[] {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.DateOfBirth.ToString(),user.BirthDate.ToString())
            };
            var Key= new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123dsasdsy76715265e726ghvshavd"));
            var avtorizacia=new SigningCredentials(Key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(

                issuer: "http://localhost:52087",
                audience: "http://localhost:52087",
                claims: claims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: avtorizacia
            ) ;
            return new JwtSecurityTokenHandler().WriteToken(token) ;
        }
        #endregion

        #region SignIn
        public bool SignIn(UserSignIn usersignIn)
        {
            try
            {
                var subject = "Hi,it's your code :)";
                var code = GenerateRendomNumber.generaterand();
                var body = $"Code For Verification:{code}";

                var meilTo = usersignIn.email;

                var signin = dbBds.Users.Where(i => i.Email == usersignIn.email).FirstOrDefault();
                if(signin==null) {
                    errorrepos.Action($"Mocemuli Mail ver moidzebna bazashi - {usersignIn.email}", ErrorTypeEnum.error);
                    return false;
                }
                else
                {
                    var tok = GeneretaJwt(signin);
                    SendEmail.sendMassege(body, subject, meilTo);
                    var verif = new _2StepVerification
                    {
                        Code = code,
                        GenerateDate = DateTime.Now,
                        userId = signin.Id,
                        jwtToken= tok
                    };
                        
                    dbBds._2StepVerification.Add(verif);
                    dbBds.SaveChanges();
                    logrepos.Action("Warmatebit dagenerirda tokeni da gaigzavna mail");
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorrepos.Action(ex.Message,ErrorTypeEnum.Fatal);
                throw;
            }
        }
        #endregion

        #region Verification
        public string Verification(VerificationRequest verRequest)
        {
            
            var verif=dbBds.Users.Where(i=>i.Email== verRequest.Email).FirstOrDefault();    
            if(verif==null)
            {
                errorrepos.Action($"Aseri meili ver moidzebna bazashi - {verRequest.Email}",ErrorTypeEnum.error);
                return null;
            }
            else
            {
                var tok=dbBds._2StepVerification.Where(i=>i.Code==verRequest.Code).FirstOrDefault();
                if (tok == null)
                {
                    return null;
                }
                else
                {
                    if((DateTime.Now.Minute- tok.GenerateDate.Minute)>=5)
                    {
                        errorrepos.Action($"kods vada gauvida, gagzavnet tavidan", ErrorTypeEnum.error);
                        return null;
                    }
                    return tok.jwtToken;
                }
            }
        }

        #endregion

        #region GetAllUser
        public List<User> GetAllUser()
        {
          return dbBds.Users.ToList();
        }
        #endregion

        #region GetUserById
        
      public  GetUserByIdResponce GetUserById(UserID userid)
        { 
          try
          {
            var user = dbBds.Users.Where(i=>i.Id==userid.ID).FirstOrDefault();
            if(user==null)
            {
                errorrepos.Action($"Mocemuli Id-it ver moidzebna momxmarebeli bazashi,id:{userid.ID}", ErrorTypeEnum.error);
                return null;
            }
            else
            {
                return new GetUserByIdResponce
                {
                    FirstName= user.FirstName,
                    LastName= user.LastName,
                    BirthDate= user.BirthDate,
                    Email= user.Email,
                    Address= user.Address,
                    PersonalNumber= user.PersonalNumber,
                    TelNumber= user.TelNumber
                };
            }

          }
          catch (Exception ex)
            {
                errorrepos.Action(ex.Message, ErrorTypeEnum.Fatal);
                throw ex;
            }
        }

        #endregion



    }
}
