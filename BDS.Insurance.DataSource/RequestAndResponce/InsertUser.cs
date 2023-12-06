using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.DataSource.RequestAndResponce
{
    public class InsertUser
    {
        [RegularExpression(@"^[A-Za-zა-ჰ\s]+$", ErrorMessage = "Invalid characters in the name.")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Za-zა-ჰ\s]+$", ErrorMessage = "Invalid characters in the lastname.")]
        public string LastName { get; set; }

        [RegularExpression(@"^[1-9]\d{10}$", ErrorMessage = "Invalid personal number")]
        public string PersonalNumber { get; set; }
        public DateTime BirthDate { get; set; }
        [RegularExpression(@"^[5]\d{8}$", ErrorMessage = "Invalid TelNumber number")]
        public string TelNumber { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
