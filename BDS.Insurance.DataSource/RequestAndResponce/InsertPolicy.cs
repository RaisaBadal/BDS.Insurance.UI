using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.DataSource.RequestAndResponce
{
    public class InsertPolicy
    {
        public DateTime PolicyStartDate { get; set; }
        public decimal CarAmount { get; set; }
        public int CarID { get; set; }
        
    }
}
