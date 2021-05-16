using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModel
{
   public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(pattern: "[A-Za-z]{3,}", ErrorMessage = "Category Name must be  more than 3 char")]
        public string CategoryName { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Description Must be Less Than 200 char")]
        [MinLength(10, ErrorMessage = "Description Must be at least 10 char")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
