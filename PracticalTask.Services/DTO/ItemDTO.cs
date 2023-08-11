using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Services.DTO
{
    public class ItemDTO
    {
        public int ItemCode { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int Cost { get; set; }
        public int Price { get; set; }
    }
}
