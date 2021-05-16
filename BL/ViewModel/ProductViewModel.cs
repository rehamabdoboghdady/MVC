using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
   public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(pattern: "[A-Za-z]{3,}", ErrorMessage = "Name must be more than 3 char")]
        public string Name { get; set; }

        [Required]
        [Range(minimum: 1000, maximum: 10000, ErrorMessage = "Price Must be more than 1000 and less than 10000")]
        public int Price { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 500, ErrorMessage = "Quantity Must be more than 1 and less than 500")]
        public int Quantity { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int CategoryID { get; set; }
    }
}
