using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.Areas.FoodCategory.Models;

namespace OnlineFoodOrder.DAL
{
    public class FoodCategory_DALBase : DALHelper
    {
        #region dbo_PR_FoodCategory_SelectAllByUserID
        public DataTable dbo_PR_FoodCategory_SelectAllByUserID()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodCategory_SelectAllByUserID");
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
        #endregion dbo_PR_FoodCategory_SelectAll

        #region dbo_PR_FoodCategory_ClientSide_SelectAllByUserID
        public DataTable dbo_PR_FoodCategory_ClientSide_SelectAllByUserID()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodCategory_ClientSide_SelectAllByUserID");
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
        #endregion dbo_PR_FoodCategory_SelectAll

        #region dbo_PR_FoodCategory_SelectByPKUserID
        public DataTable dbo_PR_FoodCategory_SelectByPKUserID(int? FoodCategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodCategory_SelectByPKUserID");
                sqlDB.AddInParameter(dbCMD, "FoodCategoryID", SqlDbType.Int, FoodCategoryID);
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

        #endregion dbo_PR_FoodCategory_SelectByPKUserID

        #region FoodCategory_InsertByUserID

        public bool dbo_FoodCategory_InsertByUserID(FoodCategoryModel modelFoodCategory)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodCategory_InsertByUserID");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "FoodCategoryName", SqlDbType.NVarChar, modelFoodCategory.FoodCategoryName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelFoodCategory.Description);
                sqlDB.AddInParameter(dbCMD, "FoodCategoryImage", SqlDbType.NVarChar, modelFoodCategory.FoodCategoryImage);
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

        #endregion dbo_FoodCategory_InsertByUserID

        #region dbo_PR_FoodCategory_UpdateByPKUserID
        public bool dbo_PR_FoodCategory_UpdateByPKUserID(FoodCategoryModel modelFoodCategory)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodCategory_UpdateByPKUserID");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "FoodCategoryID", SqlDbType.Int, modelFoodCategory.FoodCategoryID);
                sqlDB.AddInParameter(dbCMD, "FoodCategoryName", SqlDbType.NVarChar, modelFoodCategory.FoodCategoryName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelFoodCategory.Description);
                sqlDB.AddInParameter(dbCMD, "FoodCategoryImage", SqlDbType.NVarChar, modelFoodCategory.FoodCategoryImage);
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

        #endregion dbo_PR_FoodCategory_UpdateByPKUserID

        #region dbo.PR_FoodCategory_DeleteByPKUserID
        public bool dbo_PR_FoodCategory_DeleteByPKUserID(int FoodCategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodCategory_DeleteByPKUserID");
                sqlDB.AddInParameter(dbCMD, "FoodCategoryID", SqlDbType.Int, FoodCategoryID);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion dbo.PR_FoodCategory_DeleteByPKUserID

        #region PR_FoodCategory_SelectByFoodCategoryName
        public DataTable PR_FoodCategory_SelectByFoodCategoryName(string? FoodCategoryName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodCategory_SelectByFoodCategoryName");
                sqlDB.AddInParameter(dbCMD, "FoodCategoryName", SqlDbType.NVarChar, FoodCategoryName);
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
        #endregion PR_FoodCategory_SelectByFoodCategoryName
    }
}
