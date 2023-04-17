using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.Areas.FoodCategory.Models;
using OnlineFoodOrder.Areas.Product.Models;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using OnlineFoodOrder.Models;
using System.Data;
using System.Data.SqlClient;

namespace OnlineFoodOrder.Controllers
{
    [CheckAccess_Client]
    public class CartController : Controller
    {
        private IConfiguration configuration;

        public CartController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult Index()
        {
            #region SelectAll

            Cart_DAL dalCart = new Cart_DAL();
            DataTable dtCart = dalCart.PR_Cart_Client_SelectAll();
            return View("CartList", dtCart);

            #endregion
        }

        public IActionResult Save(int ProductID)
        {
            string connectionstr = this.configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(connectionstr);
            conn.Open();
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (ProductID != null)
            {

                objCmd.CommandText = "PR_Cart_Client_Insert";
                objCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
            }
            objCmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int CartID)
        {
            string connectionstr = this.configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(connectionstr);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_Cart_Client_DeleteByPK";
            cmd.Parameters.AddWithValue("@CartID", CartID);
            cmd.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");
        }
    }
}
