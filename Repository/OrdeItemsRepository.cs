using Microsoft.EntityFrameworkCore;
using OMS74019FINALCSB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Repository
{
    public class OrderItemsRepository : IOrderItems
    {
        private readonly AppDbContext _context;

        public OrderItemsRepository(AppDbContext context)
        {
            this._context = context;

        }
        public async Task<OrderItems> AddOrderItems(OrderItems orditem)
        {
            var result = await _context.OrderItems.AddAsync(orditem);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<OrderItems> DeleteOrderItems(int id)
        {
            var result = await _context.OrderItems.FirstOrDefaultAsync(c => c.OrderProductId == id);
            if (result != null)
            {
                _context.OrderItems.Remove(result);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<OrderItems> GetOrderItemByOrderProductId(int orderProductId)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(o => o.OrderProductId == orderProductId);
        }


        public async Task<IEnumerable<OrderItems>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();

        }

        public List<OrderItems> GetOrderItemsByOrderId(int orderId)
        {
            List<OrderItems> orderItems = new List<OrderItems>();
            foreach (var item in _context.OrderItems)
            {
                if (item.OrderId == orderId)
                {
                    orderItems.Add(item);
                }
            }
            return orderItems;

        }

        public async Task<OrderItems> UpdateOrderItems(OrderItems orditem)
        {
            var result = await _context.OrderItems.FirstOrDefaultAsync(ord => ord.OrderProductId == orditem.OrderProductId);
            if (result != null)
            {
                //result.Discount = orditem.Discount;
                result.ProductId = orditem.ProductId;

                result.Quantity = orditem.Quantity;
                result.Products = orditem.Products;

                result.UnitPrice = orditem.UnitPrice;
                result.TotalPrice = orditem.TotalPrice;
                result.OrderStatus = orditem.OrderStatus;
                _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }




    }
}
