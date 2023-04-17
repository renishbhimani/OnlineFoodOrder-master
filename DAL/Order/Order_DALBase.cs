using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using OnlineFoodOrder.Areas.Product.Models;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.Areas.Order.Models;

namespace OnlineFoodOrder.DAL
{
    public class Order_DALBase : DALHelper
    {
        #region dbo_PR_Order_SelectAll
        public DataTable dbo_PR_Order_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion dbo_PR_Order_SelectAll

        #region PR_Order_Client_SelectAllByCustomerID
        public DataTable PR_Order_Client_SelectAllByCustomerID()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_Client_SelectAllByCustomerID");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion PR_Order_Client_SelectAllByCustomerID

        #region PR_Order_SelectByPK
        public DataTable PR_Order_SelectByPK(int OrderID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "OrderID", SqlDbType.Int, OrderID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion PR_Order_SelectByPK

        #region PR_Order_Insert

        public bool PR_Order_Insert(OrderModel modelOrder)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_Insert");
                
                sqlDB.AddInParameter(dbCMD, "OrderDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, modelOrder.CustomerID);
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, modelOrder.ProductID);
                sqlDB.AddInParameter(dbCMD, "Quantity", SqlDbType.Int, modelOrder.Quantity);
                sqlDB.AddInParameter(dbCMD, "TotalPrice", SqlDbType.Decimal, modelOrder.TotalPrice);
                sqlDB.AddInParameter(dbCMD, "TotalAmount", SqlDbType.Decimal, modelOrder.TotalAmount);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "PaymentModeID", SqlDbType.Int, modelOrder.PaymentModeID);
                sqlDB.AddInParameter(dbCMD, "ReferenceNo", SqlDbType.NVarChar, modelOrder.ReferenceNo);
                sqlDB.AddInParameter(dbCMD, "ReferenceDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "BankName", SqlDbType.NVarChar, modelOrder.BankName);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion PR_Order_Insert

        #region PR_Order_UpdateByPK
        public bool PR_Order_UpdateByPK(OrderModel modelOrder)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "OrderID", SqlDbType.Int, modelOrder.OrderID);
                sqlDB.AddInParameter(dbCMD, "OrderDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, modelOrder.CustomerID);
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, modelOrder.ProductID);
                sqlDB.AddInParameter(dbCMD, "Quantity", SqlDbType.Int, modelOrder.Quantity);
                sqlDB.AddInParameter(dbCMD, "TotalPrice", SqlDbType.Decimal, modelOrder.TotalPrice);
                sqlDB.AddInParameter(dbCMD, "TotalAmount", SqlDbType.Decimal, modelOrder.TotalAmount);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "PaymentModeID", SqlDbType.Int, modelOrder.PaymentModeID);
                sqlDB.AddInParameter(dbCMD, "ReferenceNo", SqlDbType.NVarChar, modelOrder.ReferenceNo);
                sqlDB.AddInParameter(dbCMD, "ReferenceDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "BankName", SqlDbType.NVarChar, modelOrder.BankName);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss"));

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion PR_Order_UpdateByPK

        #region PR_Order_DeleteByPK
        public bool PR_Order_DeleteByPK(int OrderID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "OrderID", SqlDbType.Int, OrderID);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion PR_Order_DeleteByPK

        #region CustomerDropDwon

        public DataTable CustomerDropDwon()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Customer_SelectForDropDown");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);

                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion CustomerDropDwon

        #region PR_Order_SelectByCustomerName
        public DataTable PR_Order_SelectByCustomerName(int? CustomerID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Order_SelectByCustomerName");
                if (CustomerID == 0)
                {
                    sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, null);
                }
                else
                {
                    sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, CustomerID);
                }
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion PR_Order_SelectByCustomerName
    }
}
