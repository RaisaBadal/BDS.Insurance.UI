using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Models
{
    [Table("_2StepVerification")]
    public class _2StepVerification
    {
        [Key]
        public int Id { get; set; }
        public string jwtToken { get; set; }
        public string Code { get; set; }
        public DateTime GenerateDate { get; set; }
        [ForeignKey("user")]
        public int userId { get; set; }
        public User user { get; set; }
       


    }
}
