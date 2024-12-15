using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MacrosCal.Models
{
    public class Food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public double CaloriesPer100g { get; set; }
        public double ProteinPer100g { get; set; }
        public double CarbohydratesPer100g { get; set; }
        public double FatPer100g { get; set; }
        public double FiberPer100g { get; set; }
    }

}
