using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.Areas.Customer.Models;
using OnlineFoodOrder.Areas.User.Models;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using System.Data;

namespace OnlineFoodOrder.Controllers
{
    [CheckAccess_Client]
    public class CustomerController : Controller
    {
        private string? error;

        #region Index

        public IActionResult CustomerIndex()
        {
            return View("CustomerIndex");
        }

        #endregion

        #region Add
        public IActionResult Add()
        {
            /*#region Select By PK
            if (CustomerID != null)
            {
                Customer_DAL dalCustomer = new Customer_DAL();

                DataTable dtCustomer = dalCustomer.dbo_PR_Customer_SelectByPK(CustomerID);
                if (dtCustomer.Rows.Count > 0)
                {
                    CustomerModel modelCustomer = new CustomerModel();
                    foreach (DataRow dr in dtCustomer.Rows)
                    {
                        modelCustomer.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        modelCustomer.CustomerName = dr["CustomerName"].ToString();
                        modelCustomer.Address = dr["Address"].ToString();
                        modelCustomer.MobileNo = dr["MobileNo"].ToString();
                        modelCustomer.Email = dr["Email"].ToString();
                        modelCustomer.Password = dr["Password"].ToString();
                        modelCustomer.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        modelCustomer.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                    }
                    return View("CustomerAddEdit", modelCustomer);
                }
            }
            #endregion*/

            return View("Registration");
        }
        #endregion

        #region Save

        [HttpPost]
        public IActionResult Save(CustomerModel modelCustomer)
        {
            Customer_DAL dalCustomer = new Customer_DAL();

            if (modelCustomer.CustomerID == null)
            {
                if (Convert.ToBoolean(dalCustomer.dbo_PK_Customer_Insert(modelCustomer)))
                {
                    TempData["FoodCategoryInsertMessage"] = "Record inserted successfully";

                }
            }
            /*else
            {
                if (Convert.ToBoolean(dalCustomer.dbo_PR_Customer_UpdateByPK(modelCustomer)))
                {
                    TempData["FoodCategoryUpdateMessage"] = "Record Update Successfully";
                }

                return RedirectToAction("Index");
            }*/

            return RedirectToAction("CustomerIndex");
        }
        #endregion

        #region Customer Login
        [HttpPost]
        public IActionResult CustomerLogin(CustomerModel modelCustomer)
        {
            if (modelCustomer.CustomerName == null)
            {
                error += "User Name is required";
            }
            if (modelCustomer.Password == null)
            {
                error += "<br/>Password is required";
            }
            if (error != null)
            {
                TempData["Error"] = error;
                return RedirectToAction("CustomerIndex");
            }
            else
            {
                Customer_DAL dalCustomer = new Customer_DAL();
                DataTable dt = dalCustomer.dbo_PR_Customer_SelectByCustomerNamePassword(modelCustomer.CustomerName, modelCustomer.Password);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        HttpContext.Session.SetString("CustomerName", dr["CustomerName"].ToString());
                        HttpContext.Session.SetString("CustomerID", dr["CustomerID"].ToString());
                        HttpContext.Session.SetString("Password", dr["Password"].ToString());

                        break;
                    }
                }
                else
                {
                    TempData["Error"] = "User Name or Password is invalid!";
                    return RedirectToAction("CustomerIndex");
                }
                if (HttpContext.Session.GetString("CustomerName") != null && HttpContext.Session.GetString("Password") != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Customer Logout
        public IActionResult CustomerLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index1");
        }

        #endregion
    }
}
