using BusinessLogic.MacrosCal.Interfaces;
using BusinessLogic.MacrosCal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BusinessLogic.MacrosCal.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<FoodMacroResponse> GetFoodMacrosAsync()
        {
            var foodMacros = await _foodRepository.GetFoodMacrosAsync();
            var response = new FoodMacroResponse
            {
                FoodMacros = foodMacros,
                TotalCalories = foodMacros.Sum(fm => fm.Calories),
                TotalProtein = foodMacros.Sum(fm => fm.Protein),
                TotalCarbohydrates = foodMacros.Sum(fm => fm.Carbohydrates),
                TotalFat = foodMacros.Sum(fm => fm.Fat),
                TotalFiber = foodMacros.Sum(fm => fm.Fiber),
            };
            return response;
        }

        public async Task<FoodMacroDetailsResponse> GetFoodMacroDetailsAsync(FoodMacroDetailsRequest request)
        {
            var foodMacros = await _foodRepository.GetFoodMacrosAsync(request.FoodMacroQuantities);
            var response = new FoodMacroDetailsResponse
            {
                FoodMacros = foodMacros,
                TotalCalories = foodMacros.Sum(fm => fm.Calories),
                TotalProtein = foodMacros.Sum(fm => fm.Protein),
                TotalCarbohydrates = foodMacros.Sum(fm => fm.Carbohydrates),
                TotalFat = foodMacros.Sum(fm => fm.Fat),
                TotalFiber = foodMacros.Sum(fm => fm.Fiber),
            };
            return response;
        }

        public async Task AddFoodAsync(Food food)
        {
            await _foodRepository.AddFoodAsync(food);
        }

        public async Task UpdateFoodAsync(string name, Food food)
        {
            var existingFood = await _foodRepository.GetFoodAsync(name);
            if (existingFood != null)
            {
                existingFood.CaloriesPer100g = food.CaloriesPer100g;
                existingFood.ProteinPer100g = food.ProteinPer100g;
                existingFood.CarbohydratesPer100g = food.CarbohydratesPer100g;
                existingFood.FatPer100g = food.FatPer100g;
                existingFood.FiberPer100g = food.FiberPer100g;
                await _foodRepository.UpdateFoodAsync(existingFood);
            }
        }

        public async Task DeleteFoodAsync(string name)
        {
            await _foodRepository.DeleteFoodAsync(name);
        }
    }

}




