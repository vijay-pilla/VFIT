using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MacrosCal.Models
{
    public class FoodMacroResponse
    {
        public List<FoodMacro> FoodMacros { get; set; }
        public double TotalCalories { get; set; }
        public double TotalProtein { get; set; }
        public double TotalCarbohydrates { get; set; }
        public double TotalFat { get; set; }
        public double TotalFiber { get; set; }
    }

}
