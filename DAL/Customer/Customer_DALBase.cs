using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using OnlineFoodOrder.Areas.FoodCategory.Models;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.Areas.Customer.Models;

namespace OnlineFoodOrder.DAL
{
    public class Customer_DALBase : DALHelper
    {
        #region dbo_PR_Customer_SelectAll
        public DataTable dbo_PR_Customer_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Customer_SelectAll");
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
        #endregion dbo_PR_Customer_SelectAll

        #region dbo_PR_Customer_SelectByPK
        public DataTable dbo_PR_Customer_SelectByPK(int? CustomerID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Customer_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, CustomerID);
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

        #endregion dbo_PR_Customer_SelectByPK

        #region dbo_PK_Customer_Insert

        public bool dbo_PK_Customer_Insert(CustomerModel modelCustomer)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Customer_Insert");
                sqlDB.AddInParameter(dbCMD, "CustomerName", SqlDbType.NVarChar, modelCustomer.CustomerName);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelCustomer.Address);
                sqlDB.AddInParameter(dbCMD, "MobileNo", SqlDbType.NVarChar, modelCustomer.MobileNo);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelCustomer.Email);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, modelCustomer.Password);
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

        #endregion dbo_PK_Customer_Insert

        #region dbo_PR_Customer_UpdateByPK
        public bool dbo_PR_Customer_UpdateByPK(CustomerModel modelCustomer)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Customer_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, modelCustomer.CustomerID);
                sqlDB.AddInParameter(dbCMD, "CustomerName", SqlDbType.NVarChar, modelCustomer.CustomerName);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.NVarChar, modelCustomer.Address);
                sqlDB.AddInParameter(dbCMD, "MobileNo", SqlDbType.NVarChar, modelCustomer.MobileNo);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.NVarChar, modelCustomer.Email);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, modelCustomer.Password);
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

        #endregion dbo_PR_Customer_UpdateByPK

        #region dbo_PR_Customer_DeleteByPK
        public bool dbo_PR_Customer_DeleteByPK(int CustomerID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Customer_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "CustomerID", SqlDbType.Int, CustomerID);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion dbo_PR_Customer_DeleteByPK

        #region PR_Customer_SelectByCustomerName
        public DataTable PR_Customer_SelectByCustomerName(string? CustomerName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Customer_SelectByCustomerName");
                sqlDB.AddInParameter(dbCMD, "CustomerName", SqlDbType.NVarChar, CustomerName);
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
        #endregion PR_Customer_SelectByCustomerName

        #region dbo_PR_Customer_SelectByCustomerNamePassword
        public DataTable dbo_PR_Customer_SelectByCustomerNamePassword(string CustomerName, string Password)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Customer_SelectByCustomerNamePassword");

                sqlDB.AddInParameter(dbCMD, "CustomerName", SqlDbType.NVarChar, CustomerName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.NVarChar, Password);

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

        #endregion dbo_PR_Customer_SelectByCustomerNamePassword

        #region Method: dbo_PR_User_SelectByCustomerNamePassword
        public decimal? dbo_PR_User_Insert(string UserName, string Password, string Email, string Address, DateTime? CreationDate, DateTime? ModificationDate)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_User_Insert");
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, Email);
                sqlDB.AddInParameter(dbCMD, "Address", SqlDbType.VarChar, Address);
                sqlDB.AddInParameter(dbCMD, "CreationDate", SqlDbType.DateTime, CreationDate);
                sqlDB.AddInParameter(dbCMD, "ModificationDate", SqlDbType.DateTime, ModificationDate);

                var vResult = sqlDB.ExecuteScalar(dbCMD);
                if (vResult == null)
                {
                    return null;
                }

                return (decimal)Convert.ChangeType(vResult, vResult.GetType());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
