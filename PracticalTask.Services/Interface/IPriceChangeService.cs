using PracticalTask.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Services.Interface
{
    public interface IPriceChangeService
    {
        IEnumerable<PriceChangeDTO> GetPriceChanges();
        PriceChangeDTO GetPriceChangeById(int srno);
        int CreatePriceChange(PriceChangeDTO priceChangeDto);
        void UpdatePriceChange(int srno, PriceChangeDTO priceChangeDto);
        void DeletePriceChange(int srno);
    }
}
