using Microsoft.AspNetCore.Mvc;

namespace EksamenGruppe7.Controllers
{
    public class WeatherForecastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
