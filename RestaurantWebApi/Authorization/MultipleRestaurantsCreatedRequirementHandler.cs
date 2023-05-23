using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RestaurantWebApi.Entities;

namespace RestaurantWebApi.Authorization
{
    public class MultipleRestaurantsCreatedRequirementHandler : AuthorizationHandler<MultipleRestaurantsCreatedRequirement>
    {
        private readonly RestaurantDbContext _restaurantDbContext;

        public MultipleRestaurantsCreatedRequirementHandler(RestaurantDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MultipleRestaurantsCreatedRequirement requirement)
        {
            int userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            List<Restaurant> listOfRestaurants = _restaurantDbContext.Restaurants.Where(r => r.CreatedById == userId).ToList();

            var countOfRestaurants = listOfRestaurants.Count;

            if (countOfRestaurants >= requirement.MinimumRestaurantsCreated)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
            

        }
    }
}
