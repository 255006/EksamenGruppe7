using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EksamenGruppe7.Data;
using EksamenGruppe7.Models;

namespace EksamenGruppe7.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WeatherForecastController(ApplicationDbContext context)
        {
            _context = context; // Databasen
        }

        
        
        // GET: WeatherForecast
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeatherForecasts.ToListAsync());
        }

        // Funksjonalitet for å opprette ny værmelding.
        // GET: WeatherForecast/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeatherForecast/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Temperature,Comment")] WeatherForecast weatherForecast)
        {
            if (ModelState.IsValid)
            {
                weatherForecast.Id = Guid.NewGuid(); // Lag en ny unik ID for hver værmelding.
                _context.Add(weatherForecast); // Legg til databasen.
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weatherForecast);
        }


        // Funksjonalitet for å oppdatere værmelding.
        // GET: WeatherForecast/Edit/<id>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) // Dersom id finnes ikke, returner ikke funnet.
            {
                return NotFound();
            }

            var weatherForecast = await _context.WeatherForecasts.FindAsync(id);
            if (weatherForecast == null)
            {
                return NotFound();
            }
            return View(weatherForecast);
        }

        
        // POST: WeatherForecast/Edit/<id>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Date,Temperature,Comment")] WeatherForecast weatherForecast)
        {
            if (id != weatherForecast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherForecast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherForecastExists(weatherForecast.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(weatherForecast);
        }


        // Funksjonalitet for å slette værmelding.
        // GET: WeatherForecast/Delete/<id>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) // Dersom id finnes ikke, returner ikke funnet.
            {
                return NotFound();
            }

            var weatherForecast = await _context.WeatherForecasts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weatherForecast == null)
            {
                return NotFound();
            }

            return View(weatherForecast);
        }

        // POST: WeatherForecast/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var weatherForecast = await _context.WeatherForecasts.FindAsync(id);
            _context.WeatherForecasts.Remove(weatherForecast);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherForecastExists(Guid id)
        {
            return _context.WeatherForecasts.Any(e => e.Id == id);
        }
    }
}
