using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.Areas.FoodCategory.Models;
using OnlineFoodOrder.Areas.Order.Models;
using OnlineFoodOrder.Areas.Product.Models;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using System.Data;
using System.Data.SqlClient;

namespace OnlineFoodOrder.Controllers
{
    [CheckAccess_Client]
    public class OrderController : Controller
    {
        private IConfiguration configuration;

        public OrderController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult Index()
        {
            Order_DAL dalOrder = new Order_DAL();
            DataTable dtOrder = dalOrder.PR_Order_Client_SelectAllByCustomerID();
            return View("OrderList", dtOrder);
        }

        /*public IActionResult Add(int ProductID)
        {
            Product_DAL dalProduct = new Product_DAL();

            #region Select By PK

            if (ProductID != null)
            {
                DataTable dtProduct = dalProduct.dbo_PR_Product_SelectByPKUserID(ProductID);
                if (dtProduct.Rows.Count > 0)
                {
                    
                    List<OrderModel> OrderList = new List<OrderModel>();
                    foreach (DataRow dr in dtProduct.Rows)
                    {
                        OrderModel modelOrder = new OrderModel();
                        modelProduct.ProductID = Convert.ToInt32(dr["ProductID"]);
                        modelProduct.UserID = Convert.ToInt32(dr["UserID"]);
                        modelProduct.ProductName = dr["ProductName"].ToString();
                        modelProduct.Description = dr["Description"].ToString();
                        modelProduct.Price = Convert.ToDecimal(dr["Price"]);
                        modelProduct.ProductImage = dr["ProductImage"].ToString();
                        modelProduct.FoodCategoryID = Convert.ToInt32(dr["FoodCategoryID"]);
                        modelProduct.ProductImage1 = dr["ProductImage1"].ToString();
                        modelProduct.ProductImage2 = dr["ProductImage2"].ToString();
                        modelProduct.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        modelProduct.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                        ProductList.Add(modelProduct);
                    }
                    return View("OrderList", ProductList);
                }
            }
            #endregion

            return View("OrderList");
        }*/

        public IActionResult Save(int ProductID)
        {
            string connectionstr = this.configuration.GetConnectionString("myConnectionStrings");
            SqlConnection conn = new SqlConnection(connectionstr);
            conn.Open();
            SqlCommand objCmd = conn.CreateCommand();
            objCmd.CommandType = System.Data.CommandType.StoredProcedure;

            if (ProductID != null)
            {

                objCmd.CommandText = "PR_Order_Client_InsertBy";
                objCmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                objCmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                objCmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = 1;
                objCmd.Parameters.Add("@TotalPrice", SqlDbType.Int).Value = 00.00;
                objCmd.Parameters.Add("@TotalAmount", SqlDbType.Int).Value = 00.00;
                objCmd.Parameters.Add("@CreationDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                objCmd.Parameters.Add("@ModificationDate", SqlDbType.DateTime).Value = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            }
            objCmd.ExecuteNonQuery();
            conn.Close();

            return RedirectToAction("Index");
        }
    }
}
