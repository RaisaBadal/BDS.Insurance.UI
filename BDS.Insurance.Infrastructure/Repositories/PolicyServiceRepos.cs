using BDS.Insurance.Core.DBContexti;
using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.Enums;
using BDS.Insurance.DataSource.RequestAndResponce;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Infrastructure.Repositories
{
    public class PolicyServiceRepos:IPolicyRepos
    {
        private readonly DbBds dbbds;
        private readonly IErrorRepos errorrepos;
        private readonly IlogRepos logrepos;
        public PolicyServiceRepos(DbBds dbbds, IErrorRepos errorrepos, IlogRepos logrepos)
        {
            this.dbbds = dbbds;
            this.errorrepos = errorrepos;
            this.logrepos = logrepos;
        }

        #region InsertPolicy

        public GetPolicyInfo InsertPolicy(InsertPolicy insertpolicy)
        {
            using (var trans=dbbds.Database.BeginTransaction())
            {
                try
                {
                    var month = (((insertpolicy.CarAmount) * (decimal)1.79) / 12);
                    var policy = new Policy
                    {
                        PolicyStartDate = insertpolicy.PolicyStartDate,
                        PolicyEndDate = insertpolicy.PolicyStartDate.AddYears(1),
                        CarAmount = insertpolicy.CarAmount,
                        PolicyAmount = ((insertpolicy.CarAmount) * (decimal)1.79),
                        CarID = insertpolicy.CarID,
                        IsActive=true

                    };

                    var activepol = dbbds.Policys.Where(i => i.CarID == insertpolicy.CarID&&i.IsActive==true).FirstOrDefault();
                    if (activepol != null)
                    {
                        errorrepos.Action($"am manqanaze ukve arsebobs aqtiuri polisi, manqanis id:{activepol.CarID}",ErrorTypeEnum.error);
                    }
                    else
                    {
                        dbbds.Policys.Add(policy);
                        dbbds.SaveChanges();
                        logrepos.Action($"Polisi warmatebit daemata, polisis id:{policy.Id}");
                        trans.Commit();
                        var policyid = dbbds.Policys.Select(i => i.Id).Max();
                        for (int i = 0; i < 12; i++)
                        {
                            dbbds.PolicySchedules.Add(new PolicySchedule
                            {
                                PolicyId= policyid,
                                amount=month,
                                Date= DateTime.Now.AddMonths(i),
                            });
                            dbbds.SaveChanges();
                        }
                        
                        return new GetPolicyInfo
                        {
                            PolicyId = policyid,
                            CarAmount = insertpolicy.CarAmount,
                            FirstMonthFee = month
                        };
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    errorrepos.Action(ex.Message+","+ex.StackTrace,ErrorTypeEnum.Fatal);
                    trans.Rollback();
                    return null;
                   
                }
            }
           
        }

        #endregion

        #region SoftDelete

        public bool SoftDelete(PolicySoftDelete softdel)
        {
            try
            {
                var softdelPolicy=dbbds.Policys.Where(i=>i.Id==softdel.PolicyId).FirstOrDefault();
                if(softdelPolicy != null)
                {
                    softdelPolicy.IsActive = false;
                    logrepos.Action($"Policy Id-it {softdelPolicy.Id}-is statusi warmatebit sheicvala rogorc araaqtiuri");
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                errorrepos.Action(ex.Message + "," + ex.StackTrace, ErrorTypeEnum.Fatal);
                throw ex;
            }
        }
        #endregion

        #region GetPolicyByCarId
        public Policy GetPolicyByCarId(CarById carid)
        {
            try
            {
                var car = dbbds.Policys.Where(i => i.CarID == carid.CarID).FirstOrDefault();
                if(car==null)
                {
                    errorrepos.Action($"Policy gadacemuli manqanis aidit ver moidzebna bazashi,manqanis id:{car.CarID}", ErrorTypeEnum.error);
                    return null;
                }
                else
                {

                    return car;
                }
            }
            catch (Exception ex)
            {
                errorrepos.Action(ex.Message+","+ex.StackTrace,ErrorTypeEnum.Fatal);
                throw;
            }
        }
        #endregion

        #region GetAllPolicies
        public List<Policy> GetAllPolicies()
        {
            return dbbds.Policys.ToList();
        }
        #endregion

        #region GetPolicysByPolicyId
        public Policy GetPolicysByPolicyId(GetPolicyById policyID)
        {
            try
            {
                var policy = dbbds.Policys.Where(i => i.Id == policyID.Id).FirstOrDefault();
                if (policy == null)
                {
                    errorrepos.Action($"Policy ver moidzebna gadacemuli PolicyId-is mixedvit, id:{policy.Id}", ErrorTypeEnum.error);
                    return null;
                }
                else
                {
                    return policy;
                }
            }
            catch (Exception ex)
            {
                errorrepos.Action(ex.Message,ErrorTypeEnum.Fatal);
                throw;
            }
        }
        #endregion

    }
}
