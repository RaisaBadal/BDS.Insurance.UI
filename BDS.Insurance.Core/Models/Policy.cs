using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Models
{
    [Table("Policy")]
    public class Policy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime PolicyStartDate { get; set; }
        [Required]
        public DateTime PolicyEndDate { get; set; }
        [Required]
        public decimal CarAmount { get; set; }
        [Required]
        public decimal PolicyAmount { get; set; }
        public bool IsActive { get; set; }
     
        [ForeignKey("car")]
        public int CarID { get; set; }
        public Car car { get; set; }
        public List<PolicySchedule> Schedules { get; set; }


    }
}
