using BDS.Insurance.DataSource.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.DataSource.RequestAndResponce
{
    public class CarResponce
    {
        public string CarNumber { get; set; }
        public string VinCode { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public EngineTypeEnum EngineType { get; set; }
    }
}
