using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace OnlineFoodOrder.DAL
{
    public class Cart_DALBase : DALHelper
    {
        #region PR_Cart_Client_SelectAll
        public DataTable PR_Cart_Client_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Cart_Client_SelectAll");
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
        #endregion PR_Cart_Client_SelectAll

        #region PR_Cart_SelectByPK
        public DataTable PR_Cart_SelectByPK(int ProductID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_ClientSide_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, ProductID);
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

        #endregion PR_Cart_SelectByPK
    }
}
