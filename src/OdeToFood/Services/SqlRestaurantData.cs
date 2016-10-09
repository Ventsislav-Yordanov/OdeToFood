using System.Collections.Generic;
using OdeToFood.Entities;
using System.Linq;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            this.context = context;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            this.context.Restaurants.Add(restaurant);
            this.context.SaveChanges();

            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return this.context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return this.context.Restaurants;
        }
    }
}
