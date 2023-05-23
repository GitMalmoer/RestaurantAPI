using RestaurantWebApi.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestaurantWebApi
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
               var pendingMigrations = _dbContext.Database.GetPendingMigrations();
               if (pendingMigrations != null || pendingMigrations.Any())
               {
                   _dbContext.Database.Migrate();
               }

                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRole();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }


                if(!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRole()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },

                new Role()
                {
                    Name = "Manager"
                },

                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;

        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "Kfc stands for kentucky fried chicken",
                    ContactEmail="contact@kfc.com",
                    HasDelivery=true,

                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville hot chicken",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "frikin chicken Nuggets",
                            Price = 5.30M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Krakow",
                        Street = "Dluga 5",
                        PostalCode = "72-033"
                    }
                },
                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "McDonald stands for Ronald McDonald and he is cool gui",
                    ContactEmail="contact@mcdonald.com",
                    HasDelivery=true,

                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "2foryou",
                            Price = 7.30M,
                        },

                        new Dish()
                        {
                            Name = "Drwals Burger",
                            Price = 10.30M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Szczecin",
                        Street = "Kurkaniepamietam",
                        PostalCode = "23-230"
                    }
                }

            };
            return restaurants;
        }

    }
}
