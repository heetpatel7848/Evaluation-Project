using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask.Models
{
    public class Item
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Srno { get; set; }
        [Required]
        [StringLength(100)]
        public int ItemCode { get; set; }
        [Required]
        [StringLength(50)]
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public int Cost { get; set; }
        public int Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }


        public Item()
        {
            CreateDate = DateTime.Now; // Initialize CreateDate with the current date and time
            UpdateDate = DateTime.Now; // Initialize UpdateDate with the current date and time
        }
    }
}
