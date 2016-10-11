using System.Collections.Generic;
using OdeToFood.Entities;
using System.Linq;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private static List<Restaurant> restaurants;

        static InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant() { Id = 1, Name = "The happy beers" },
                new Restaurant() { Id = 2, Name = "Bar and Grill Joka" },
                new Restaurant() { Id = 3, Name = "The cat" },
            };
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(restaurant);

            return restaurant;
        }

        public void Commit()
        {
            // no operation here
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants;
        }
    }
}
