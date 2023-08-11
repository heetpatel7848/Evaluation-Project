using PracticalTask.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Models.Repository
{
    public class PriceChangeRepository : IPriceChangeRepository
    {
        private readonly PracticalTaskContext _context;

        public PriceChangeRepository(PracticalTaskContext context)
        {
            _context = context;
        }

        public IEnumerable<PriceChange> GetPriceChanges()
        {
            return _context.PriceChanges.ToList();
        }

        public PriceChange GetPriceChangeById(int srno)
        {
            return _context.PriceChanges.FirstOrDefault(pc => pc.Srno == srno);
        }

        public int CreatePriceChange(PriceChange priceChange)
        {
            _context.PriceChanges.Add(priceChange);
            _context.SaveChanges();
            return priceChange.Srno;
        }

        public void UpdatePriceChange(PriceChange priceChange)
        {
            _context.PriceChanges.Update(priceChange);
            _context.SaveChanges();
        }

        public void DeletePriceChange(int srno)
        {
            var priceChangeToDelete = _context.PriceChanges.FirstOrDefault(pc => pc.Srno == srno);
            if (priceChangeToDelete != null)
            {
                _context.PriceChanges.Remove(priceChangeToDelete);
                _context.SaveChanges();
            }
        }

    }
}