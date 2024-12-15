using BusinessLogic.MacrosCal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MacrosCal.Interfaces
{
    public interface IFoodItemService
    {
        Task<IEnumerable<FoodItem>> GetAllFoodItemsAsync();
        Task<FoodItem> GetFoodItemByNameAsync(string name);
        Task<string> AddFoodItemsAsync(IEnumerable<FoodItem> foodItems);
        Task<string> UpdateFoodItemAsync(FoodItem foodItem);
        Task<string> DeleteFoodItemAsync(string name);
        Task<(IEnumerable<FoodItem> FoodItems, decimal TotalProtein, decimal TotalCarbs, decimal TotalFibre, decimal TotalFat, decimal TotalCalories)>
            CalculateMacrosAsync(IEnumerable<FoodInput> foodInputs);
    }
}
