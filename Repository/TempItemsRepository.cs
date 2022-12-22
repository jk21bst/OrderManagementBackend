using Microsoft.EntityFrameworkCore;
using OMS74019FINALCSB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Repository
{
    public class TempItemsRepository : ITempItems
    {
        private readonly AppDbContext _context;
        public TempItemsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<TempItems> AddTempItems(TempItems tempItem)
        {
            var result = await _context.TempItems.AddAsync(tempItem);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TempItems> DeleteTempItems(int tempItemId)
        {
            var result = await _context.TempItems.FirstOrDefaultAsync(t => t.TempProductId == tempItemId);
            if (result != null)
            {
                _context.TempItems.Remove(result);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<TempItems>> GetTempItems()
        {
            return await _context.TempItems.ToListAsync();
        }

        public List<TempItems> GetTempItemsByCustId(int custId)
        {
            List<TempItems> list = new List<TempItems>();
            foreach (var item in _context.TempItems)
            {
                if (item.CustId == custId)
                {
                    list.Add(item);
                }

            }
            return list;
        }

        public async Task<TempItems> GetTempItemsById(int TempItemId)
        {
            return await _context.TempItems
                   .FirstOrDefaultAsync(e => e.TempProductId == TempItemId);
        }
    }
}
