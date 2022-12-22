﻿using Microsoft.EntityFrameworkCore;
using OMS74019FINALCSB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Repository
{
    public class OrdersRepository : IOrders
    {
        private readonly AppDbContext _context;

        public OrdersRepository(AppDbContext context)
        {
            this._context = context;

        }
        public async Task<IEnumerable<Orders>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<Orders> GetOrderByOrderId(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        }



        public List<Orders> GetOrderByCustId(int CustId)
        {
            List<Orders> orders = new List<Orders>();
            foreach (var order in _context.Orders)
            {
                if (order.CustId == CustId)
                {
                    orders.Add(order);
                }

            }
            return orders;
        }


        public async Task<Orders> AddOrder(Orders order)
        {
            var result = await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Orders> DeleteOrder(int id)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(c => c.OrderId == id);
            if (result != null)
            {
                _context.Orders.Remove(result);
                await _context.SaveChangesAsync();
            }
            return null;
        }


        public async Task<Orders> UpdateOrder(Orders order)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(ord => ord.OrderId == order.OrderId);
            if (result != null)
            {
                result.OrderQuantity = order.OrderQuantity;
                result.OrderStatus = order.OrderStatus;
                result.OrderDate = order.OrderDate;
                result.OrderCost = order.OrderCost;
                result.CustId = order.CustId;
                result.Customer = order.Customer;
                _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;


        }
    }
}
    
