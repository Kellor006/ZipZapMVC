using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZipZap.Models;

namespace ZipZap.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult zzPage()
        {
            ZipZapApp model = new();

            model.ZipValue = 3;
            model.ZapValue = 5;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult zzPage(ZipZapApp zipZapApp)
        {
            List<string> zzItems = new();

            bool zip;
            bool zap;

            for (int i = 1; i <= 100; i++)
            {
                zip = (i % zipZapApp.ZipValue == 0);
                zap = (i % zipZapApp.ZapValue == 0);

                if (zip == true && zap == true)
                {
                    zzItems.Add("ZipZap");
                }
                else if (zip == true)
                {
                    zzItems.Add("Zip");
                }
                else if (zap == true)
                {
                    zzItems.Add("Zap");
                }
                else
                {
                    zzItems.Add(i.ToString());
                }
            }

            zipZapApp.Result = zzItems;

            return View(zipZapApp);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}