using OMS74019FINALCSB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Repository
{
   public interface ITempItems
    {
        Task<IEnumerable<TempItems>> GetTempItems();
        Task<TempItems> GetTempItemsById(int TempProductId);
        List<TempItems> GetTempItemsByCustId(int custId);
        Task<TempItems> AddTempItems(TempItems tempItem);
        Task<TempItems> DeleteTempItems(int tempItemId);

    }
}
