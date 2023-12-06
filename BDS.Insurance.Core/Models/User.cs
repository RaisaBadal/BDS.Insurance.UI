using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PersonalNumber { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string TelNumber { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }


    }
}
