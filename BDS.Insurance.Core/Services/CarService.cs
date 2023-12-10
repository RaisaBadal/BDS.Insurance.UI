using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.Services
{
    public class CarService:ICar
    {
        private readonly ICarRepos icarrepos;
        public CarService(ICarRepos icarrepos)
        {
            this.icarrepos = icarrepos;
        }

        public bool DeleteCarById(DeleteCar deletecar)
        {
           return icarrepos.DeleteCarById(deletecar);
        }

        public List<Car> GetAllCar()
        {
            return icarrepos.GetAllCar();
        }

        public CarResponce GetCarById(CarById car)
        {
            return icarrepos.GetCarById(car);
        }

        public bool InsertCar(InsertCar insertcar, int UserID)
        {
            return icarrepos.InsertCar(insertcar, UserID);
        }
    }
}
