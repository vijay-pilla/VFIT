using BusinessLogic.MacrosCal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MacrosCal.Interfaces
{
    public interface IFoodService
    {
        Task<FoodMacroResponse> GetFoodMacrosAsync();
        Task<FoodMacroDetailsResponse> GetFoodMacroDetailsAsync(FoodMacroDetailsRequest request);
        Task AddFoodAsync(Food food);
        Task UpdateFoodAsync(string name, Food food);
        Task DeleteFoodAsync(string name);
    }

}
