using BDS.Insurance.DataSource.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.DataSource.RequestAndResponce
{
    public class InsertCar
    {
        public string CarNumber { get; set; }
        public string VinCode { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public EngineTypeEnum EngineType { get; set; }
    }
}
