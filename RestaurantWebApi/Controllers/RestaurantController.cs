using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantWebApi.Entities;
using RestaurantWebApi.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using RestaurantWebApi.Services;

namespace RestaurantWebApi.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var id = _restaurantService.Create(dto);
            

            return Created($"api/restaurant/{id}",null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);
            return NoContent();
        }


        [HttpGet]
        //[Authorize(Policy = "MinimumAmountOfRestaurants")]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll([FromQuery] RestaurantQuery restaurantQuery)
        {
            var restaurantsDtos = _restaurantService.GetAll(restaurantQuery);

            return Ok(restaurantsDtos);
        }

        [HttpGet]
        [Route("{Id}")]
        [AllowAnonymous]
        public ActionResult<RestaurantDto> Get([FromRoute]int Id)
        {
            var restaurant = _restaurantService.GetById(Id);

            if(restaurant is null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateRestaurantDto dto,[FromRoute] int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            _restaurantService.Edit(dto, id);
            return Ok();
        }
    }
}
