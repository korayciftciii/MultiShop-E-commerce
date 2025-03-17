using MultiShop.Cargo.BusinnessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinnessLayer.Concrete
{
   public class CargoStatueManager:ICargoStatueService
    {
        private readonly ICargoStatueDal _cargoStatueDal;

        public CargoStatueManager(ICargoStatueDal cargoStatueDal)
        {
            _cargoStatueDal = cargoStatueDal;
        }

        public void TDelete(int id)
        {
      _cargoStatueDal.Delete(id);
        }

        public List<CargoStatue> TGetAll()
        {
            return _cargoStatueDal.GetAll();
        }

        public CargoStatue TGetById(int id)
        {
            return _cargoStatueDal.GetById(id);
        }

        public void TInsert(CargoStatue item)
        {
            _cargoStatueDal.Insert(item);
        }

        public void TUpdate(CargoStatue item)
        {
           _cargoStatueDal.Update(item);
        }
    }
}
