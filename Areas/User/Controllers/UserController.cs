using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.Areas.User.Models;
using OnlineFoodOrder.DAL;
using System.Data;

namespace OnlineFoodOrder.Areas.User.Controllers
{
    [Area("User")]
    [Route("User/[Controller]/[action]")]
    public class UserController : Controller
    {
        private string? error;

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserModel modelUser)
        {
            if (modelUser.UserName == null)
            {
                error += "User Name is required";
            }
            if (modelUser.Password == null)
            {
                error += "<br/>Password is required";
            }
            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("Index");
            }
            else
            {
                User_DAL dalUser = new User_DAL();
                DataTable dt = dalUser.dbo_PR_User_SelectByUserNamePassword(modelUser.UserName, modelUser.Password);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("UserName", dr["UserName"].ToString());
                        HttpContext.Session.SetString("UserID", dr["UserID"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());

                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("Index");
                }
                if (HttpContext.Session.GetString("UserName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return RedirectToAction("Index", "FoodCategory", new { Area = "FoodCategory" });
                }
            }
            return RedirectToAction("Index", "FoodCategory", new { Area = "FoodCategory" });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
