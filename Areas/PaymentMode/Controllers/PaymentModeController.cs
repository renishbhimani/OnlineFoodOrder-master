using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using System.Data;

namespace OnlineFoodOrder.Areas.PaymentMode.Controllers
{
    [CheckAccess]
    [Area("PaymentMode")]
    [Route("PaymentMode/[Controller]/[action]")]
    public class PaymentModeController : Controller
    {
        #region Index

        #region dbo_PR_PaymentMode_SelectAll
        public IActionResult Index()
        {

            PaymentMode_DAL dalLOC = new PaymentMode_DAL();
            DataTable dtPaymentMode = dalLOC.dbo_PR_PaymentMode_SelectAll();
            return View("PaymentModeList", dtPaymentMode);

        }
        #endregion dbo_PR_PaymentMode_SelectAll

        #endregion Index
    }
}

