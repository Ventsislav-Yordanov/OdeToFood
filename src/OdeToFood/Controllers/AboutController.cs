using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("company/[controller]/[action]")]
    public class AboutController 
    {
        public string Phone()
        {
            return "+359 883 42 42 42";
        }

        public string Address()
        {
            return "Ruse, Bulgaria";
        }
    }
}
