using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmogTracker.API;
using SmogTracker.Models;

namespace SmogTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmogData _smogData;

        public HomeController(ISmogData smogData)
        {
            _smogData = smogData;
        }

        public IActionResult Index(bool refresh)
        {
            if(refresh)
            {
                _smogData.RefreshData();
            }

            return View(_smogData.DataModel);
        }

        public IActionResult History()
        {
            return View(_smogData.DataModel);
        }

        public IActionResult Forecast()
        {
            return View(_smogData.DataModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
