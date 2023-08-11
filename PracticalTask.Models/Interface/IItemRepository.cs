using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Models.Interface
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItemById(int srno);
        int CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(int srno);
    }
}
