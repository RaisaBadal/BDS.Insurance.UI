using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Models
{
    [Table("PolicySchedule")]
    public class PolicySchedule
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal amount { get; set; }
        [ForeignKey("policy")]
        public int PolicyId { get; set; }
        public Policy policy { get; set; }
    }
}
