using OMS74019FINALCSB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Repository
{
   public interface IOrderItems
    {

        Task<IEnumerable<OrderItems>> GetOrderItems();
        Task<OrderItems> GetOrderItemByOrderProductId(int orderProductId);
        List<OrderItems> GetOrderItemsByOrderId(int orderId);

        Task<OrderItems> UpdateOrderItems(OrderItems orditem);
        Task<OrderItems> DeleteOrderItems(int id);
        Task<OrderItems> AddOrderItems(OrderItems orditem);

    }
}
