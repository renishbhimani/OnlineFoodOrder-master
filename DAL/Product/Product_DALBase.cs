using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using OnlineFoodOrder.BAL;
using System.Data.Common;
using System.Data;
using OnlineFoodOrder.Areas.FoodCategory.Models;
using OnlineFoodOrder.Areas.Product.Models;

namespace OnlineFoodOrder.DAL
{
    public class Product_DALBase : DALHelper
    {
        #region dbo_PR_Product_SelectAllByUserID
        public DataTable dbo_PR_Product_SelectAllByUserID()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_SelectAllByUserID");
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
        #endregion dbo_PR_Product_SelectAllByUserID

        #region dbo_PR_Product_ClientSide_SelectAll
        public DataTable dbo_PR_Product_ClientSide_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_ClientSide_SelectAll");
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
        #endregion dbo_PR_Product_ClientSide_SelectAll

        #region dbo_PR_Product_ClientSide_SelectAllByFoodCategoryID
        public DataTable dbo_PR_Product_ClientSide_SelectAllByFoodCategoryID(int FoodCategoryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_ClientSide_SelectAllByFoodCategoryID");
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
        #endregion dbo_PR_Product_ClientSide_SelectAllByFoodCategoryID

        #region dbo_PR_Product_SelectByPKUserID
        public DataTable dbo_PR_Product_SelectByPKUserID(int ProductID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_SelectByPKUserID");
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

        #endregion dbo_PR_FoodCategory_SelectByPKUserID

        #region dbo_PR_Product_ClientSide_SelectByPK
        public DataTable dbo_PR_Product_ClientSide_SelectByPK(int ProductID)
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

        #endregion dbo_PR_Product_ClientSide_SelectByPK

        #region PR_Product_InsertByUserID

        public bool PR_Product_InsertByUserID(ProductModel modelProduct)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_InsertByUserID");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "ProductName", SqlDbType.NVarChar, modelProduct.ProductName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelProduct.Description);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.Decimal, modelProduct.Price);
                sqlDB.AddInParameter(dbCMD, "ProductImage", SqlDbType.NVarChar, modelProduct.ProductImage);
                sqlDB.AddInParameter(dbCMD, "FoodCategoryID", SqlDbType.Int, modelProduct.FoodCategoryID);
                sqlDB.AddInParameter(dbCMD, "ProductImage1", SqlDbType.NVarChar, modelProduct.ProductImage1);
                sqlDB.AddInParameter(dbCMD, "ProductImage2", SqlDbType.NVarChar, modelProduct.ProductImage2);
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

        #endregion PR_Product_InsertByUserID

        #region dbo_PR_Product_UpdateByPKUserID
        public bool dbo_PR_Product_UpdateByPKUserID(ProductModel modelProduct)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_UpdateByPKUserID");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, modelProduct.ProductID);
                sqlDB.AddInParameter(dbCMD, "ProductName", SqlDbType.NVarChar, modelProduct.ProductName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, modelProduct.Description);
                sqlDB.AddInParameter(dbCMD, "Price", SqlDbType.Decimal, modelProduct.Price);
                sqlDB.AddInParameter(dbCMD, "ProductImage", SqlDbType.NVarChar, modelProduct.ProductImage);
                sqlDB.AddInParameter(dbCMD, "FoodCategoryID", SqlDbType.Int, modelProduct.FoodCategoryID);
                sqlDB.AddInParameter(dbCMD, "ProductImage1", SqlDbType.NVarChar, modelProduct.ProductImage1);
                sqlDB.AddInParameter(dbCMD, "ProductImage2", SqlDbType.NVarChar, modelProduct.ProductImage2);
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

        #endregion dbo_PR_Product_UpdateByPKUserID

        #region dbo.PR_Product_DeleteByPKUserID
        public bool dbo_PR_Product_DeleteByPKUserID(int ProductID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_DeleteByPKUserID");
                sqlDB.AddInParameter(dbCMD, "ProductID", SqlDbType.Int, ProductID);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion dbo.PR_Product_DeleteByPKUserID

        #region FoodCategoryDropDwon

        public DataTable FoodCategoryDropDwon()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_FoodCategory_SelectForDropDownByUserID");
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

        #endregion FoodCategoryDropDwon

        #region PR_Product_SelectByFoodCategoryIDProductName
        public DataTable PR_Product_SelectByFoodCategoryIDProductName(int? FoodCategoryID, string? ProductName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Product_SelectByFoodCategoryIDProductName");
                if (FoodCategoryID == 0)
                {
                    sqlDB.AddInParameter(dbCMD, "FoodCategoryID", SqlDbType.Int, null);
                }
                else
                {
                    sqlDB.AddInParameter(dbCMD, "FoodCategoryID", SqlDbType.Int, FoodCategoryID);
                }
                sqlDB.AddInParameter(dbCMD, "ProductName", SqlDbType.NVarChar, ProductName);
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
        #endregion PR_Product_SelectByFoodCategoryIDProductName
    }
}
