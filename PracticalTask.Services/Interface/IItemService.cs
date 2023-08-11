using PracticalTask.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Services.Interface
{
    public interface IItemService
    {
        IEnumerable<ItemDTO> GetItems();
        ItemDTO GetItemById(int srno);
        int CreateItem(ItemDTO itemDto);
        void UpdateItem(int srno, ItemDTO itemDto);
        void DeleteItem(int srno);
    }
}
