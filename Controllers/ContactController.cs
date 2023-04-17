using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.BAL;

namespace OnlineFoodOrder.Controllers
{
    [CheckAccess_Client]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View("Contact");
        }
    }
}
