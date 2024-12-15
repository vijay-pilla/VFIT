using BusinessLogic.MacrosCal.Interfaces;
using BusinessLogic.MacrosCal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.MacrosCal.Services
{
    public class FoodItemService : IFoodItemService
    {
        private readonly IFoodItemRepository _foodItemRepository;

        public FoodItemService(IFoodItemRepository foodItemRepository)
        {
            _foodItemRepository = foodItemRepository;
        }

        public async Task<IEnumerable<FoodItem>> GetAllFoodItemsAsync()
        {
            return await _foodItemRepository.GetAllFoodItemsAsync();
        }

        public async Task<FoodItem> GetFoodItemByNameAsync(string name)
        {
            return await _foodItemRepository.GetFoodItemByNameAsync(name);
        }

        public async Task<string> AddFoodItemsAsync(IEnumerable<FoodItem> foodItems)
        {
            foreach (var foodItem in foodItems)
            {
                var existingItem = await _foodItemRepository.GetFoodItemByNameAsync(foodItem.Name);
                if (existingItem != null)
                {
                    throw new ArgumentException($"Food item '{foodItem.Name}' already exists.");
                }
                await _foodItemRepository.AddFoodItemAsync(foodItem);
            }
            return "Food items added successfully.";
        }

        public async Task<string> UpdateFoodItemAsync(FoodItem foodItem)
        {
            var existingItem = await _foodItemRepository.GetFoodItemByNameAsync(foodItem.Name);
            if (existingItem == null)
            {
                throw new ArgumentException($"Food item '{foodItem.Name}' not found.");
            }
            await _foodItemRepository.UpdateFoodItemAsync(foodItem);
            return $"Food item '{foodItem.Name}' updated successfully.";
        }

        public async Task<string> DeleteFoodItemAsync(string name)
        {
            var existingItem = await _foodItemRepository.GetFoodItemByNameAsync(name);
            if (existingItem == null)
            {
                throw new ArgumentException($"Food item '{name}' not found.");
            }
            await _foodItemRepository.DeleteFoodItemAsync(name);
            return $"Food item '{name}' deleted successfully.";
        }

        public async Task<(IEnumerable<FoodItem> FoodItems, decimal TotalProtein, decimal TotalCarbs, decimal TotalFibre, decimal TotalFat, decimal TotalCalories)>
            CalculateMacrosAsync(IEnumerable<FoodInput> foodInputs)
        {
            var foodItems = new List<FoodItem>();
            decimal totalProtein = 0, totalCarbs = 0, totalFibre = 0, totalFat = 0, totalCalories = 0;

            foreach (var input in foodInputs)
            {
                var foodItem = await _foodItemRepository.GetFoodItemByNameAsync(input.Name);
                if (foodItem == null) continue;

                var multiplier = input.Quantity / 100;
                foodItem.Protein *= multiplier;
                foodItem.Carbs *= multiplier;
                foodItem.Fibre *= multiplier;
                foodItem.Fat *= multiplier;
                foodItem.TotalCalories *= multiplier;

                foodItems.Add(foodItem);
                totalProtein += foodItem.Protein;
                totalCarbs += foodItem.Carbs;
                totalFibre += foodItem.Fibre;
                totalFat += foodItem.Fat;
                totalCalories += foodItem.TotalCalories;
            }

            return (foodItems, totalProtein, totalCarbs, totalFibre, totalFat, totalCalories);
        }
    }
}
