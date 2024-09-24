using Multishop.CargoService.DataAccess.Abstract;
using Multishop.CargoService.DataAccess.Concrete;
using Multishop.CargoService.DataAccess.Repositories;
using Multishop.CargoService.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.CargoService.DataAccess.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EfCargoCustomerDal(CargoContext context) : base(context)
        {
        }
    }
}
