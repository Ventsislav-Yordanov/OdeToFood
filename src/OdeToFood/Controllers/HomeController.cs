using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = this.restaurantData.GetAll();
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
        public IActionResult Edit(int id)
        {
            var model = this.restaurantData.Get(id);
            if (model == null)
            {
                return this.RedirectToAction(nameof(HomeController.Index));
            }

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            var restaurant = this.restaurantData.Get(id);
            if (this.ModelState.IsValid)
            {
                restaurant.Cuisine = model.Cuisine;
                restaurant.Name = model.Name;
                this.restaurantData.Commit();

                return this.RedirectToAction(nameof(this.Details), new { id = restaurant.Id });
            }

            return this.View(restaurant);
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
                this.restaurantData.Commit();

                return this.RedirectToAction(nameof(this.Details), new { id = restaurant.Id });
            }

            return this.View();
        }
    }
}
