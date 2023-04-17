using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.Areas.Customer.Models;
using OnlineFoodOrder.Areas.FoodCategory.Models;
using OnlineFoodOrder.Areas.Order.Models;
using OnlineFoodOrder.Areas.Product.Models;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using System.Data;

namespace OnlineFoodOrder.Areas.Order.Controllers
{
    [CheckAccess]
    [Area("Order")]
    [Route("Order/[Controller]/[action]")]
    public class OrderController : Controller
    {
        #region Index
        public IActionResult Index()
        {
            /*#region Customer Drop Down

            Order_DAL dalOrder = new Order_DAL();

            DataTable dtCustomer = dalOrder.CustomerDropDwon();
            List<CustomerDropDwonModel> CustomerDropDwonListPage = new List<CustomerDropDwonModel>();
            foreach (DataRow dr in dtCustomer.Rows)
            {
                CustomerDropDwonModel modelCustomerDropDwon = new CustomerDropDwonModel();
                modelCustomerDropDwon.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                modelCustomerDropDwon.CustomerName = dr["CustomerName"].ToString();
                CustomerDropDwonListPage.Add(modelCustomerDropDwon);
            }
            ViewBag.CustomerList = CustomerDropDwonListPage;

            #endregion*/

            Order_DAL dalOrder= new Order_DAL();
            DataTable dtOrder = dalOrder.dbo_PR_Order_SelectAll();
            List<OrderModel> OrderList = new List<OrderModel>();
            foreach(DataRow dr in dtOrder.Rows)
            {
                OrderModel modelOrder = new OrderModel();
                modelOrder.OrderID = Convert.ToInt32(dr["OrderID"]);
                modelOrder.UserID = Convert.ToInt32(dr["UserID"]);
                modelOrder.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                modelOrder.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                modelOrder.CustomerName = dr["CustomerName"].ToString();
                modelOrder.Address = dr["Address"].ToString();
                modelOrder.MobileNo = dr["MobileNo"].ToString();
                modelOrder.ProductID = Convert.ToInt32(dr["ProductID"]);
                modelOrder.Quantity = Convert.ToInt32(dr["Quantity"]);
                modelOrder.TotalPrice = Convert.ToDecimal(dr["TotalPrice"]);
                modelOrder.TotalAmount = Convert.ToDecimal(dr["TotalAmount"]);
                modelOrder.PaymentModeID = Convert.ToInt32(dr["PaymentModeID"]);
                modelOrder.ReferenceNo = dr["ReferenceNo"].ToString();
                modelOrder.ReferenceDate = Convert.ToDateTime(dr["ReferenceDate"]);
                modelOrder.BankName = dr["BankName"].ToString();
                modelOrder.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                modelOrder.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                OrderList.Add(modelOrder);
            }
            return View("OrderList", OrderList);

        }

        #endregion Index

        #region Add
        public IActionResult Add(int OrderID)
        {
            #region Select By PK

            if (OrderID != null)
            {
                Order_DAL dalOrder = new Order_DAL();
                DataTable dtOrder = dalOrder.PR_Order_SelectByPK(OrderID);
                if (dtOrder.Rows.Count > 0)
                {
                    OrderModel modelOrder = new OrderModel();
                    foreach (DataRow dr in dtOrder.Rows)
                    {
                        modelOrder.OrderID = Convert.ToInt32(dr["OrderID"]);
                        modelOrder.UserID = Convert.ToInt32(dr["UserID"]);
                        modelOrder.OrderDate = Convert.ToDateTime(dr["OrderDate"]);
                        modelOrder.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                        modelOrder.ProductID = Convert.ToInt32(dr["ProductID"]);
                        modelOrder.Quantity = Convert.ToInt32(dr["Quantity"]);
                        modelOrder.TotalPrice = Convert.ToDecimal(dr["TotalPrice"]);
                        modelOrder.TotalAmount = Convert.ToDecimal(dr["TotalAmount"]);
                        modelOrder.PaymentModeID = Convert.ToInt32(dr["PaymentModeID"]);
                        modelOrder.ReferenceNo = dr["ReferenceNo"].ToString();
                        modelOrder.ReferenceDate = Convert.ToDateTime(dr["ReferenceDate"]);
                        modelOrder.BankName = dr["BankName"].ToString();
                        modelOrder.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        modelOrder.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                    }
                    return View("OrderAddEdit", modelOrder);
                }
            }
            #endregion

            return View("OrderAddEdit");
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(OrderModel modelOrder)
        {
            Order_DAL dalOrder = new Order_DAL();

            if (modelOrder.OrderID == null)
            {
                if (Convert.ToBoolean(dalOrder.PR_Order_Insert(modelOrder)))
                {
                    TempData["OrderInsertMessage"] = "Record inserted successfully";

                }
            }
            else
            {
                if (Convert.ToBoolean(dalOrder.PR_Order_UpdateByPK(modelOrder)))
                {
                    TempData["OrderUpdateMessage"] = "Record Update Successfully";
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Add");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int OrderID)
        {

            Order_DAL dalOrder = new Order_DAL();

            if (Convert.ToBoolean(dalOrder.PR_Order_DeleteByPK(OrderID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
        #endregion Delete

        #region Order Filter
        public IActionResult PR_Order_SelectByCustomerName(int CustomerID)
        {
            Order_DAL dalOrder = new Order_DAL();
            DataTable dtOrderFilter = dalOrder.PR_Order_SelectByCustomerName(CustomerID);

            DataTable dtCustomer = dalOrder.CustomerDropDwon();
            List<CustomerDropDwonModel> CustomerDropDwonListPage = new List<CustomerDropDwonModel>();
            foreach (DataRow dr in dtCustomer.Rows)
            {
                CustomerDropDwonModel modelCustomerDropDwon = new CustomerDropDwonModel();
                modelCustomerDropDwon.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                modelCustomerDropDwon.CustomerName = dr["CustomerName"].ToString();
                CustomerDropDwonListPage.Add(modelCustomerDropDwon);
            }
            ViewBag.CustomerList = CustomerDropDwonListPage;

            return View("OrderList", dtOrderFilter);

        }
        #endregion
    }
}
