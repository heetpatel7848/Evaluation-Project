using PracticalTask.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Models.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly PracticalTaskContext _context;

        public ItemRepository(PracticalTaskContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int srno)
        {
            return _context.Items.FirstOrDefault(item => item.Srno == srno);
        }

        public int CreateItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item.Srno;
        }

        public void UpdateItem(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }

        public void DeleteItem(int srno)
        {
            var item = _context.Items.FirstOrDefault(item => item.Srno == srno);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
