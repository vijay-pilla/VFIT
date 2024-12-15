using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MacrosCal.Models
{
    public class FoodItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Protein { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Carbs { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Fibre { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Fat { get; set; }

        [Range(0, double.MaxValue)]
        public decimal TotalCalories { get; set; }
    }
}
