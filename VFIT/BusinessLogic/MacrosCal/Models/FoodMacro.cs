using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MacrosCal.Models
{
    public class FoodMacro
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public double Quantity { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
    }

}
