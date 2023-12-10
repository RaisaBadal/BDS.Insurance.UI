using BDS.Insurance.DataSource.Enums;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CarNumber { get; set; }
        public string VinCode { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public EngineTypeEnum EngineType { get; set; }
        [ForeignKey("user")]
        public int UserID { get; set; }
        public User user { get; set; }  
        public Policy policy { get; set; }


    }
}
