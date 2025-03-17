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
 public class CargoCustomerManager:ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public void TDelete(int id)
        {
           _cargoCustomerDal.Delete(id);
        }

        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomerDal.GetAll();
        }

        public CargoCustomer TGetById(int id)
        {
           return _cargoCustomerDal.GetById(id);
        }

        public void TInsert(CargoCustomer item)
        {
             _cargoCustomerDal.Insert(item);
        }

        public void TUpdate(CargoCustomer item)
        {
          _cargoCustomerDal.Update(item);
        }
    }
}
