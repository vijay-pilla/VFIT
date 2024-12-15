using BusinessLogic.MacrosCal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MacrosCal.Interfaces
{
    public interface IFoodRepository
    {
        Task<List<FoodMacro>> GetFoodMacrosAsync();
        Task<List<FoodMacro>> GetFoodMacrosAsync(List<FoodMacroQuantity> foodMacroQuantities);
        Task<Food> GetFoodAsync(string name);
        Task AddFoodAsync(Food food);
        Task UpdateFoodAsync(Food food);
        Task DeleteFoodAsync(string name);
    }
}
