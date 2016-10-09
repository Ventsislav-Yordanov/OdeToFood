using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IGreeter greeter;
        private IRestaurantData restaurantData;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            this.restaurantData = restaurantData;
            this.greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = this.restaurantData.GetAll();
            model.CurrentMessage = this.greeter.GetGreeting();
            return this.View(model);
        }

        public IActionResult Details(int id)
        {
            var model = this.restaurantData.Get(id);
            if (model == null)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;

                restaurant = this.restaurantData.Add(restaurant);

                return this.RedirectToAction(nameof(this.Details), new { id = restaurant.Id });
            }

            return this.View();
        }
    }
}
