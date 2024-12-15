using BusinessLogic.MacrosCal.Interfaces;
using BusinessLogic.MacrosCal.Models;
using DataAccess.FoodData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.FoodData
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly FoodContext _context;

        public FoodItemRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FoodItem>> GetAllFoodItemsAsync()
        {
            return await _context.FoodItems.ToListAsync();
        }

        public async Task<FoodItem> GetFoodItemByNameAsync(string name)
        {
            return await _context.FoodItems.FirstOrDefaultAsync(f => f.Name == name);
        }

        public async Task AddFoodItemAsync(FoodItem foodItem)
        {
            _context.FoodItems.Add(foodItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFoodItemAsync(FoodItem foodItem)
        {
            _context.FoodItems.Update(foodItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodItemAsync(string name)
        {
            var foodItem = await GetFoodItemByNameAsync(name);
            if (foodItem != null)
            {
                _context.FoodItems.Remove(foodItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
