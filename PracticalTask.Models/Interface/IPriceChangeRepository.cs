using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Models.Interface
{
    public interface IPriceChangeRepository
    {
        IEnumerable<PriceChange> GetPriceChanges();
        PriceChange GetPriceChangeById(int srno);
        int CreatePriceChange(PriceChange priceChange);
        void UpdatePriceChange(PriceChange priceChange);
        void DeletePriceChange(int srno);
    }
}
