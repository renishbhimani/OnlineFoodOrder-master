using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using System.Data;

namespace OnlineFoodOrder.Controllers
{
    [CheckAccess_Client]
    public class FoodCategoryController : Controller
    {
        public IActionResult Index()
        {
            FoodCategory_DAL dalFoodCategory = new FoodCategory_DAL();
            DataTable dtFoodCategory = dalFoodCategory.dbo_PR_FoodCategory_ClientSide_SelectAllByUserID();
            return View("FoodCategoryList", dtFoodCategory);
            /*return View("FoodCategoryList");*/
        }
    }
}
