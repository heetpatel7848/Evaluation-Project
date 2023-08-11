using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Services.DTO
{
    public class PriceChangeDTO
    {
        public int ItemCode { get; set; }
        public decimal OldCost { get; set; }
        public string Increase_Decrease { get; set; }
        public string PriceType { get; set; }
        public string PriceUpdate { get; set; }
        public int NewCost { get; set; }
        public int OldPrice { get; set; }
        public int NewPrice { get; set; }
    }
}
