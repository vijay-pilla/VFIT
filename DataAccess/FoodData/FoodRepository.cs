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
    public class FoodRepository : IFoodRepository
    {
        private readonly FoodContext _context;

        public FoodRepository(FoodContext context)
        {
            _context = context;
        }

        public async Task<List<FoodMacro>> GetFoodMacrosAsync()
        {
            return await _context.FoodMacros.Include(fm => fm.FoodId)
            .ToListAsync();
        }
        public async Task<List<FoodMacro>> GetFoodMacrosAsync(List<FoodMacroQuantity> foodMacroQuantities)
        {
            var foodMacros = new List<FoodMacro>();

            foreach (var foodMacroQuantity in foodMacroQuantities)
            {
                var food = await _context.Foods.SingleOrDefaultAsync(f => f.Name == foodMacroQuantity.FoodName);
                if (food != null)
                {
                    var foodMacro = new FoodMacro
                    {
                        //FoodId = (link unavailable),
                        Quantity = foodMacroQuantity.Quantity,
                        Calories = food.CaloriesPer100g / 100 * foodMacroQuantity.Quantity,
                        Protein = food.ProteinPer100g / 100 * foodMacroQuantity.Quantity,
                        Carbohydrates = food.CarbohydratesPer100g / 100 * foodMacroQuantity.Quantity,
                        Fat = food.FatPer100g / 100 * foodMacroQuantity.Quantity,
                        Fiber = food.FiberPer100g / 100 * foodMacroQuantity.Quantity,
                    };
                    foodMacros.Add(foodMacro);
                }
            }

            return foodMacros;
        }

        public async Task<Food> GetFoodAsync(string name)
        {
            return await _context.Foods.SingleOrDefaultAsync(f => f.Name == name);
        }

        public async Task AddFoodAsync(Food food)
        {
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFoodAsync(Food food)
        {
            _context.Foods.Update(food);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFoodAsync(string name)
        {
            var food = await GetFoodAsync(name);
            if (food != null)
            {
                _context.Foods.Remove(food);
                await _context.SaveChangesAsync();
            }
        }
    }

}
