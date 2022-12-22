using OMS74019FINALCSB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Repository
{
   public interface IProducts
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<Products> GetProductByProductId(int id);
        Task<Products> AddProduct(Products product);
        Task<Products> UpdateProduct(Products product);
        Task<Products> DeleteProduct(int id);
    }
}
