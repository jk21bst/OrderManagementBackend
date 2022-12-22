using Microsoft.EntityFrameworkCore;
using OMS74019FINALCSB.Data.Models;
using OMS74019FINALCSB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB
{
    public class ProductsRepository : IProducts
    {
        private readonly AppDbContext _context;
        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Products> GetProductByProductId(int ProductId)
        {
            return await _context.Products
                 .FirstOrDefaultAsync(e => e.ProductId == ProductId);
        }

        //public async Task<Products> GetItemByProductId(int ProductId)
        //{
        //    return await _context.Products
        //           .FirstOrDefaultAsync(e => e.ProductId == ProductId);
        //}


        public async Task<Products> AddProduct(Products product)
        {
            var result = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        //public async Task<Products> AddProduct(Products product)
        //{
        //    var result = await _context.Products.AddAsync(product);
        //    await _context.SaveChangesAsync();
        //    return result.Entity;
        //}



        public async Task<Products> DeleteProduct(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(i => i.ProductId == id);
            if (result != null)
            {
                _context.Products.Remove(result);
                await _context.SaveChangesAsync();
                return result;

            }
            return null;
        }
        //public async Task<Products> DeleteProduct(int id)
        //{
        //    var result = await _context.Products.FirstOrDefaultAsync(i => i.ProductId == id);
        //    if (result != null)
        //    {
        //        _context.Products.Remove(result);
        //        await _context.SaveChangesAsync();
        //        return result;

        //    }
        //    return null;
        //}



        public async Task<Products> UpdateProduct(Products product)
        {
            var result = await _context.Products.FirstOrDefaultAsync(e => e.ProductId == product.ProductId);
            if (result != null)
            {
                result.ProductCategory = product.ProductCategory;
                result.ProductCost = product.ProductCost;
                //result.ItemDiscount = result.ItemDiscount;
                result.ProductQuantity = product.ProductQuantity;
                result.ProductUrl = product.ProductUrl;


                _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //public Task<IEnumerable<Products>> GetProducts()
        //{
        //    throw new NotImplementedException();
        //}



        //public async Task<Products> UpdateProduct(Products product)
        //{
        //    var result = await _context.Products.FirstOrDefaultAsync(e => e.ProductId == product.ProductId);
        //    if (result != null)
        //    {
        //        result.ProductCategory = product.ProductCategory;
        //        result.ProductCost = product.ProductCost;
        //        //result.ItemDiscount = result.ItemDiscount;
        //        result.ProductQuantity = product.ProductQuantity;
        //        result.ProductUrl = product.ProductUrl;


        //        _context.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        await _context.SaveChangesAsync();
        //        return result;
        //    }
        //    return null;
        //}






    }

}
