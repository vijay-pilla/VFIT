using BusinessLogic.MacrosCal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MacrosCal.Interfaces
{
    public interface IFoodItemRepository
    {
        Task<IEnumerable<FoodItem>> GetAllFoodItemsAsync();
        Task<FoodItem> GetFoodItemByNameAsync(string name);
        Task AddFoodItemAsync(FoodItem foodItem);
        Task UpdateFoodItemAsync(FoodItem foodItem);
        Task DeleteFoodItemAsync(string name);
    }
}
