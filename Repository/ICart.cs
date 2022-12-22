using OMS74019FINALCSB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Repository
{
    public interface ICart
    {
        Task<IEnumerable<Cart>> GetAllCartItems();
        Task<Cart> GetCartByCartId(int CartId);
        List<Cart> GetCartItemsByCartId(int cartId);
        Task<Cart> AddCart(Cart cart);
        Task<Cart> DeleteCart(int CartId);
        Task<Cart> UpdateCart(Cart cart);
    }
}
