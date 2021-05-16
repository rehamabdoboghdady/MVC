using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
   public class OrderDetailesViewModel
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(minimum: 2000, maximum: 10000)]
        public int TotalPrice { get; set; }
    }
}
