using BusinessLogic.MacrosCal.Interfaces;
using BusinessLogic.MacrosCal.Models;
using BusinessLogic.MacrosCal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace VFIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vfitController : ControllerBase
    {
        private readonly IFoodItemService _foodItemService;
        private readonly IFoodService _foodService;
        public vfitController(IFoodItemService foodItemService, IFoodService foodService)
        {
            _foodItemService = foodItemService;
            _foodService = foodService;

        }
        //[HttpGet]
        //public async Task<ActionResult<FoodMacroResponse>> GetFoodMacrosAsync()
        //{
        //    return await _foodService.GetFoodMacrosAsync();
        //}

        //[HttpGet("details")]
        //public async Task<ActionResult<FoodMacroDetailsResponse>> GetFoodMacroDetailsAsync(FoodMacroDetailsRequest request)
        //{
        //    return await _foodService.GetFoodMacroDetailsAsync(request);
        //}

        //[HttpPost]
        //public async Task<ActionResult<Food>> AddFoodAsync(Food food)
        //{
        //    await _foodService.AddFoodAsync(food);
        //    return CreatedAtAction(nameof(GetFoodMacrosAsync), new { name = food.Name }, food);
        //}

        //[HttpPut("{name1}")]
        //public async Task<ActionResult> UpdateFoodAsync(string name1, Food food)
        //{
         //   await _foodService.UpdateFoodAsync(name1, food);
         //   return NoContent();
        //}

        //[HttpDelete("{name1}")]
        //public async Task<ActionResult> DeleteFoodAsync(string name1)
        //{
         //   await _foodService.DeleteFoodAsync(name1);
         //   return NoContent();
        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
            try
            {
                var foodItems = await _foodItemService.GetAllFoodItemsAsync();
                return Ok(foodItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<FoodItem>> GetFoodItem(string name)
        {
            try
            {
                var foodItem = await _foodItemService.GetFoodItemByNameAsync(name);

                if (foodItem == null)
                {
                    return NotFound($"Food item '{name}' not found.");
                }

                return Ok(foodItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddFoodItems([FromBody] IEnumerable<FoodItem> foodItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _foodItemService.AddFoodItemsAsync(foodItems);
                return CreatedAtAction(nameof(GetFoodItems), new { }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{name}")]
        public async Task<ActionResult> UpdateFoodItem(string name, [FromBody] FoodItem foodItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (name != foodItem.Name)
            {
                return BadRequest("Food item name mismatch.");
            }

            try
            {
                var result = await _foodItemService.UpdateFoodItemAsync(foodItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult> DeleteFoodItem(string name)
        {
            try
            {
                var result = await _foodItemService.DeleteFoodItemAsync(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("calculate-macros")]
        public async Task<ActionResult> CalculateMacros([FromBody, Required] IEnumerable<FoodInput> foodInputs)
        {
            try
            {
                var result = await _foodItemService.CalculateMacrosAsync(foodInputs);
                return Ok(JsonConvert.SerializeObject(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
