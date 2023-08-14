using PracticalTask.Models;
using PracticalTask.Services.DTO;

namespace PracticalTask.Services.Interface
{
    public interface IPriceChangeService
    {
        IEnumerable<PriceChangeDTO> GetPriceChanges();
        PriceChangeDTO GetPriceChangeById(int srno);
        int CreatePriceChange(PriceChangeDTO priceChangeDto);
        void UpdatePriceChange(int srno, PriceChangeDTO priceChangeDto);
        void DeletePriceChange(int srno);
        void ApplyPriceChangesToItems(int srno);
        IEnumerable<Item> GetItemsByItemCodes(List<int> itemCodes);

    }
}
