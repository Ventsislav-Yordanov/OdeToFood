using System.Collections.Generic;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            this.restaurants = new List<Restaurant>
            {
                new Restaurant() { Id = 1, Name = "The happy beers" },
                new Restaurant() { Id = 2, Name = "Bar and Grill Joka" },
                new Restaurant() { Id = 3, Name = "The cat" },
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return this.restaurants;
        }
    }
}
