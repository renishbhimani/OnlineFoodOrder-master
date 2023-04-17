using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;

namespace OnlineFoodOrder.DAL
{
    public class PaymentMode_DALBase : DALHelper
    {
        #region dbo_PR_PaymentMode_SelectAll
        public DataTable dbo_PR_PaymentMode_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_PaymentMode_SelectAll");
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
        #endregion dbo_PR_PaymentMode_SelectAll
    }
}
