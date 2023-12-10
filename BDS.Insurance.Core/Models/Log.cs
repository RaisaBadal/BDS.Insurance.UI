using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Models
{
    [Table("Logs")]
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public string Text { get; set; }
        public DateTime TimeofOccured { get; set; }


    }
}
