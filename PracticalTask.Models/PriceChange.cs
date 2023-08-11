using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Models
{
    public  class PriceChange
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Srno { get; set; }

        [Required]
        public int ItemCode { get; set; }

        public int OldCost { get; set; }
        public string Increase_Decrease { get; set; }
        public string PriceType { get; set; }
        public string PriceUpdate { get; set; }
        public int NewCost { get; set; }
        public int OldPrice { get; set; }
        public int NewPrice { get; set; }

        public DateTime CreateDate { get; set; }

        public PriceChange()
        {
            CreateDate = DateTime.Now;
        }
    }
}
