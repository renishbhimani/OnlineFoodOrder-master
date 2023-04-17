using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using OnlineFoodOrder.Models;
using System.Data;
using System.Diagnostics;

namespace OnlineFoodOrder.Controllers
{
    [CheckAccess_Client]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            FoodCategory_DAL dalFoodCategory = new FoodCategory_DAL();
            DataTable dtFoodCategory = dalFoodCategory.dbo_PR_FoodCategory_ClientSide_SelectAllByUserID();
            return View("Index",dtFoodCategory);
            /*return View();*/
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}