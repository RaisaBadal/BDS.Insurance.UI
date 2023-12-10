using BDS.Insurance.Core.DBContexti;
using BDS.Insurance.Core.Interfaces;
using BDS.Insurance.Core.Models;
using BDS.Insurance.DataSource.Enums;
using BDS.Insurance.DataSource.RequestAndResponce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BDS.Insurance.Infrastructure.Repositories
{
    public class CarServiceRepos:ICarRepos
    {
        private readonly DbBds dbBds;
        private readonly IErrorRepos errorrepos;
        private readonly IlogRepos logrepos;
        public CarServiceRepos(DbBds dbBds, IErrorRepos errorrepos, IlogRepos logrepos)
        {
            this.dbBds = dbBds;
            this.errorrepos = errorrepos;
            this.logrepos = logrepos;
        }


        #region InsertCar
        public bool InsertCar(InsertCar insertcar,int UserID)
        {
            using(var trans = dbBds.Database.BeginTransaction())
            {
                try
                {
                    var cars = new Car
                    {
                        Model = insertcar.Model,
                        Brand = insertcar.Brand,
                        CarNumber = insertcar.CarNumber,
                        VinCode = insertcar.VinCode,
                        EngineType = insertcar.EngineType,
                        UserID = UserID
                    };

                    var carNum = dbBds.Cars.Where(i => i.CarNumber == insertcar.CarNumber).FirstOrDefault();
                    var caruser=dbBds.Cars.Where(i=>i.UserID== UserID&&i.CarNumber==insertcar.CarNumber).FirstOrDefault();
                    if(caruser!=null)
                    {
                        errorrepos.Action($"manqana am nomrit ukve arsebobs bazashi:{caruser.CarNumber}", ErrorTypeEnum.Info);
                        return false;
                    }

                    if (carNum == null)
                    {
                      
                        dbBds.Cars.Add(cars);
                        dbBds.SaveChanges();
                        logrepos.Action($"Manqana warmatebit daemata bazashi, Id:{cars.Id}");
                        trans.Commit();
                        return true;
                    }

                    else
                    {
                       if(carNum.UserID!=UserID)
                        {
                            var activpol=dbBds.Policys.Where(i=>i.CarID==carNum.Id&&i.IsActive==true).FirstOrDefault();
                            if (activpol != null)
                            {
                                errorrepos.Action($"Mocemul manqanaze arsebobs aqtiuri polisi, manqanis Id:{activpol.CarID}", ErrorTypeEnum.Warning);
                                return false;
                            }
                            else
                            {
                                dbBds.Cars.Add(cars);
                                dbBds.SaveChanges();
                                logrepos.Action($"Manqana warmatebit daemata bazashi, manqanis nomeria:{cars.CarNumber}");
                                trans.Commit();
                                return true;
                            }
                          
                        }
                    }
                    return false;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    trans.Rollback();
                    return false;
                }
            }
        }
        #endregion

        #region DeleteCar

        public bool DeleteCarById(DeleteCar deletecar)
        {
            try
            {
                var car = dbBds.Cars.Where(i => i.Id == deletecar.CarID).FirstOrDefault();
                if(car != null)
                {
                    dbBds.Cars.Remove(car);
                    logrepos.Action($"Manqana warmatebit waishala bazidan, manqanis nomeri: {car.CarNumber}");
                    return true;
                }
                else
                {
                    errorrepos.Action($"Moxda shecdoma manqana ver waishala, manqanis nomeri:{car.CarNumber}",ErrorTypeEnum.error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorrepos.Action(ex.Message + " ," + ex.StackTrace, ErrorTypeEnum.error);
                throw ex;
            }
        }
        #endregion

        #region GetCarById
        public CarResponce GetCarById(CarById car)
        {
            try
            {
                var carid = dbBds.Cars.Where(i => i.Id == car.CarID).FirstOrDefault();
                if (carid == null)
                {
                    errorrepos.Action($"Mocemuli Id-it ver moidzebna manqana, manqanis Id:{carid.Id}", ErrorTypeEnum.error);
                    return null;
                }
                else
                {
                    return new CarResponce
                    {
                        Model = carid.Model,
                        Brand = carid.Brand,
                        CarNumber = carid.CarNumber,
                        EngineType = carid.EngineType,
                        VinCode = carid.VinCode
                    };
                }
            }
            
           

            catch (Exception ex)
            {
                errorrepos.Action(ex.Message+","+ex.StackTrace, ErrorTypeEnum.Fatal);
                throw ex;
            }
        }
        #endregion

        #region GetAllCar
        public List<Car> GetAllCar()
        {
            return dbBds.Cars.ToList();
        }
        #endregion
    }
}

