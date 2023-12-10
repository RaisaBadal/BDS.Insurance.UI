using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.DataSource.RequestAndResponce
{
    public class GetPolicyInfo
    {
        public decimal CarAmount { get; set; }
        public int PolicyId { get; set; }
        public decimal FirstMonthFee { get; set; }
    }
}
