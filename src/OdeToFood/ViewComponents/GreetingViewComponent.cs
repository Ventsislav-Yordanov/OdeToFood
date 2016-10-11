using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class GreetingViewComponent : ViewComponent
    {
        private IGreeter greeter;

        public GreetingViewComponent(IGreeter greeter)
        {
            this.greeter = greeter;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = this.greeter.GetGreeting();
            return Task.FromResult<IViewComponentResult>(this.View("Default", model));
        }
    }
}
