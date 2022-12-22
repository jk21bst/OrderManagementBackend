using OMS74019FINALCSB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Repository
{
   public interface IOrders
    {
        Task<IEnumerable<Orders>> GetOrders();


        Task<Orders> GetOrderByOrderId(int id);
        //Task<Orders> GetOrderByCustId(int Custid);
        Task<Orders> UpdateOrder(Orders order);
        Task<Orders> AddOrder(Orders order);
        Task<Orders> DeleteOrder(int id);
        List<Orders> GetOrderByCustId(int CustId);
    }
}
