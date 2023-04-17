using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.Areas.Customer.Models;
using OnlineFoodOrder.Areas.FoodCategory.Models;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using System.Data;

namespace OnlineFoodOrder.Areas.Customer.Controllers
{
    [CheckAccess]
    [Area("Customer")]
    [Route("Customer/[Controller]/[action]")]
    public class CustomerController : Controller
    {
        #region Index

        #region dbo_PR_Customer_SelectAll
        [Route("/Customer")]
        public IActionResult Index()
        {
            Customer_DAL dalCustomer = new Customer_DAL();
            DataTable dtCustomer = dalCustomer.dbo_PR_Customer_SelectAll();
            return View("CustomerList", dtCustomer);
        }
        #endregion dbo_PR_Customer_SelectAll

        #endregion Index

        #region Add
        public IActionResult Add(int? CustomerID)
        {
            #region Select By PK
            if (CustomerID != null)
            {
                Customer_DAL dalCustomer= new Customer_DAL();

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
            #endregion

            return View("CustomerAddEdit");
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
            else
            {
                if (Convert.ToBoolean(dalCustomer.dbo_PR_Customer_UpdateByPK(modelCustomer)))
                {
                    TempData["FoodCategoryUpdateMessage"] = "Record Update Successfully";
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Add", "OrderDetail" , new {Area = "OrderDetail" });
        }
        #endregion

        #region Delete
        public IActionResult Delete(int CustomerID)
        {
            Customer_DAL dalCustomer = new Customer_DAL();

            if (Convert.ToBoolean(dalCustomer.dbo_PR_Customer_DeleteByPK(CustomerID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
        #endregion Delete

        #region Customer Filter
        public IActionResult PR_Customer_SelectByCustomerName(string? CustomerName)
        {
            Customer_DAL dalCustomer = new Customer_DAL();
            DataTable dtCustomerFilter = dalCustomer.PR_Customer_SelectByCustomerName(CustomerName);
            return View("CustomerList", dtCustomerFilter);
        }
        #endregion
    }
}
