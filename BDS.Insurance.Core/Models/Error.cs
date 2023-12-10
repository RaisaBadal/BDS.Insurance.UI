using BDS.Insurance.DataSource.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Models
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int ErrorID { get; set; }
        public string Text { get; set; }
        public ErrorTypeEnum ErrorType { get; set; }
        public DateTime TimeofOccured { get; set; }
    }
}
