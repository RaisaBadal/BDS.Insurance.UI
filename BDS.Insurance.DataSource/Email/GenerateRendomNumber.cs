using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.DataSource.Email
{
    public static class GenerateRendomNumber
    {
        public static string generaterand()
        {
            Random rand=new Random();
            string code=rand.Next(100000,999999).ToString();
            return code;
        }
    }
}
