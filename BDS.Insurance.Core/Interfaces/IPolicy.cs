using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Interfaces
{
    public interface IPolicy
    {
        GetPolicyInfo InsertPolicy(InsertPolicy insertpolicy);
        bool SoftDelete(PolicySoftDelete softdel);
        Policy GetPolicyByCarId(CarById carid);
        List<Policy> GetAllPolicies();
        Policy GetPolicysByPolicyId(GetPolicyById policyID);
    }
}
