using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Interfaces
{
    public interface ICarRepos
    {
        bool InsertCar(InsertCar insertcar, int UserID);
        List<Car> GetAllCar();
        CarResponce GetCarById(CarById car);
        bool DeleteCarById(DeleteCar deletecar);
    }
}
