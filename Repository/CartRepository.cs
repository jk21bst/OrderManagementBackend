using Microsoft.EntityFrameworkCore;
using OMS74019FINALCSB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Repository
{
        public class CartRepository : ICart
        {
            private readonly AppDbContext _context;

            public CartRepository(AppDbContext context)
            {
                this._context = context;

            }
            public async Task<Cart> AddCart(Cart cart)
            {
                var result = await _context.Cart.AddAsync(cart);
                await _context.SaveChangesAsync();
                return result.Entity;
            }

            public async Task<Cart> DeleteCart(int CartId)
            {
                var result = await _context.Cart.FirstOrDefaultAsync(t => t.CartId == CartId);
                if (result != null)
                {
                    _context.Cart.Remove(result);
                    await _context.SaveChangesAsync();
                }
                return null;
            }

            public async Task<IEnumerable<Cart>> GetAllCartItems()
            {
                return await _context.Cart.ToListAsync();
            }

            public async Task<Cart> GetCartByCartId(int CartId)
            {
                return await _context.Cart.FirstOrDefaultAsync(c => c.CartId == CartId);

            }

            public List<Cart> GetCartItemsByCartId(int cartId)
            {
                List<Cart> list = new List<Cart>();
                foreach (var item in _context.Cart)
                {
                    if (item.CartId == cartId)
                    {
                        list.Add(item);
                    }

                }
                return list;
            }
            public async Task<Cart> UpdateCart(Cart cart)
            {
                var result = await _context.Cart.FirstOrDefaultAsync(e => e.CartId == cart.CartId);
                if (result != null)
                {
                    result.CartQuantity = cart.CartQuantity;
                    result.CartAmount = cart.CartAmount;
                    result.CustId = cart.CustId;
                    result.ProductId = cart.ProductId;



                    _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return result;
                }
                return null;
            }
        }
    }
