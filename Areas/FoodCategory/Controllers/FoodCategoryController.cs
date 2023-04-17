using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.Areas.Customer.Models;
using OnlineFoodOrder.Areas.FoodCategory.Models;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using System.Data;

namespace OnlineFoodOrder.Areas.FoodCategory.Controllers
{
    [CheckAccess]
    [Area("FoodCategory")]
    [Route("FoodCategory/[Controller]/[action]")]
    public class FoodCategoryController : Controller
    {
        #region Index

        #region dbo_PR_FoodCategory_SelectAll
        public IActionResult Index()
        {
            FoodCategory_DAL dalFoodCategory = new FoodCategory_DAL();
            DataTable dtFoodCategory = dalFoodCategory.dbo_PR_FoodCategory_SelectAllByUserID();
            return View("FoodCategoryList", dtFoodCategory);
        }
        #endregion dbo_PR_FoodCategory_SelectAll

        #endregion Index

        #region Add
        public IActionResult Add(int? FoodCategoryID)
        {
            #region Select By PK
            if (FoodCategoryID != null)
            {
                FoodCategory_DAL dalFoodCategory = new FoodCategory_DAL();

                DataTable dtFoodCategory = dalFoodCategory.dbo_PR_FoodCategory_SelectByPKUserID(FoodCategoryID);
                if (dtFoodCategory.Rows.Count > 0)
                {
                    FoodCategoryModel modelFoodCategory = new FoodCategoryModel();
                    foreach (DataRow dr in dtFoodCategory.Rows)
                    {
                        modelFoodCategory.FoodCategoryID = Convert.ToInt32(dr["FoodCategoryID"]);
                        modelFoodCategory.UserID = Convert.ToInt32(dr["UserID"]);
                        modelFoodCategory.FoodCategoryName = dr["FoodCategoryName"].ToString();
                        modelFoodCategory.Description = dr["Description"].ToString();
                        modelFoodCategory.FoodCategoryImage = dr["FoodCategoryImage"].ToString();
                        modelFoodCategory.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        modelFoodCategory.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                    }
                    return View("FoodCategoryAddEdit", modelFoodCategory);
                }
            }
            #endregion

            return View("FoodCategoryAddEdit");
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(FoodCategoryModel modelFoodCategory)
        { 
            #region PhotoPath
            if (modelFoodCategory.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, modelFoodCategory.File.FileName);
                modelFoodCategory.FoodCategoryImage = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelFoodCategory.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelFoodCategory.File.CopyTo(stream);
                }

            }
            #endregion

            FoodCategory_DAL dalFoodCategory = new FoodCategory_DAL();

            if (modelFoodCategory.FoodCategoryID == null)
            {
                if (Convert.ToBoolean(dalFoodCategory.dbo_FoodCategory_InsertByUserID(modelFoodCategory)))
                {
                    TempData["FoodCategoryInsertMessage"] = "Record inserted successfully";
                }
            }
            else
            {
                if (Convert.ToBoolean(dalFoodCategory.dbo_PR_FoodCategory_UpdateByPKUserID(modelFoodCategory)))
                {
                    TempData["FoodCategoryUpdateMessage"] = "Record Update Successfully";
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Add");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int FoodCategoryID)
        {

            FoodCategory_DAL dalFoodCategory = new FoodCategory_DAL();

            if (Convert.ToBoolean(dalFoodCategory.dbo_PR_FoodCategory_DeleteByPKUserID(FoodCategoryID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
        #endregion Delete

        #region FoodCategory Filter
        public IActionResult PR_FoodCategory_SelectByFoodCategoryName(string? FoodCategoryName)
        {
            FoodCategory_DAL dalFoodCategory = new FoodCategory_DAL();
            DataTable dtFoodCategoryFilter = dalFoodCategory.PR_FoodCategory_SelectByFoodCategoryName(FoodCategoryName);
            return View("FoodCategoryList", dtFoodCategoryFilter);

        }
        #endregion
    }
}
