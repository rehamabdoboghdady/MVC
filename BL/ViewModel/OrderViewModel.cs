using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
   public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Description Less Than 200 char")]
        [MinLength(40, ErrorMessage = "Description Must be at least 40 char")]
        public string Description { get; set; }
        [Required]
        [Range(minimum: 2000, maximum: 10000)]
        public int Price { get; set; }
        public int discount { get; set; }

     
    }
}
