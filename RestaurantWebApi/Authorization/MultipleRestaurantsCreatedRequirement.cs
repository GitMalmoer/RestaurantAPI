using Microsoft.AspNetCore.Authorization;

namespace RestaurantWebApi.Authorization
{
    public class MultipleRestaurantsCreatedRequirement : IAuthorizationRequirement
    {
        public int MinimumRestaurantsCreated { get; }

        public MultipleRestaurantsCreatedRequirement(int minimumRestaurantsCreated)
        {
            MinimumRestaurantsCreated = minimumRestaurantsCreated;
        }

    }
}
