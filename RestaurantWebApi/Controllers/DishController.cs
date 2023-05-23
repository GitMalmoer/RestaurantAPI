using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebApi.Models;
using RestaurantWebApi.Services;

namespace RestaurantWebApi.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }


        [HttpPost]
        public ActionResult Post([FromRoute] int restaurantId, [FromBody] CreateDishDto dto)
        {
            var newDishId = _dishService.Create(restaurantId,dto);

            return Created($"api/{restaurantId}/dish/{newDishId}", null);
        }

        [HttpDelete]
        public ActionResult DeleteAllDishes([FromRoute] int restaurantId)
        {
            _dishService.DeleteAll(restaurantId);

            return NoContent();
        }

        [HttpDelete("{dishId}")]
        public ActionResult DeleteOne([FromRoute] int restaurantId, [FromRoute] int dishId)
        {
            _dishService.DeleteOneDish(restaurantId, dishId);
                return NoContent();
        }


        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute] int restaurantId , [FromRoute] int dishId)
        {
            var dish = _dishService.GetById(restaurantId, dishId);

            return Ok(dish);
        }

        [HttpGet]
        public ActionResult<List<DishDto>> GetAll([FromRoute] int restaurantId)
        {
            var dishes = _dishService.GetAll(restaurantId);
            return Ok(dishes);
        }

    }
}
