using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

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
            var model = this.restaurantData.GetAll();
            return View(model);
        }
    }
}
