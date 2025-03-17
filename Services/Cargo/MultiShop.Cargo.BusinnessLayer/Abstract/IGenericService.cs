using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinnessLayer.Abstract
{
  public interface IGenericService<T> where T : class
    {
        void TInsert(T item);
        void TUpdate(T item);
        void TDelete(int id);
        T TGetById(int id);
        List<T> TGetAll();
    }
}
