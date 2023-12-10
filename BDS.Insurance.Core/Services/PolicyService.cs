using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Services
{
    public class PolicyService : IPolicy
    {
        private readonly IPolicyRepos iservice;
        public PolicyService(IPolicyRepos iservice)
        {
            this.iservice = iservice;
        }

        public List<Policy> GetAllPolicies()
        {
            return iservice.GetAllPolicies();
        }

        public Policy GetPolicyByCarId(CarById carid)
        {
            return iservice.GetPolicyByCarId(carid);
        }

        public Policy GetPolicysByPolicyId(GetPolicyById policyID)
        {
            return iservice.GetPolicysByPolicyId(policyID);
        }

        public GetPolicyInfo InsertPolicy(InsertPolicy insertpolicy)
        {
            return iservice.InsertPolicy(insertpolicy);
        }

        public bool SoftDelete(PolicySoftDelete softdel)
        {
            return iservice.SoftDelete(softdel);
        }
    }
}
