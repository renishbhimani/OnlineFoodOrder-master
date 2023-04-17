using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.Areas.FoodCategory.Models;
using OnlineFoodOrder.Areas.Product.Models;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using System.Data;

namespace OnlineFoodOrder.Areas.Product.Controllers
{
    [CheckAccess]
    [Area("Product")]
    [Route("Product/[Controller]/[action]")]
    public class ProductController : Controller
    {
        #region Index

        #region dbo_PR_Product_SelectAll
        public IActionResult Index()
        {
            #region FoodCategory Drop Down

            Product_DAL dalProduct = new Product_DAL();

            DataTable dtFoodCategory = dalProduct.FoodCategoryDropDwon();
            List<FoodCategoryDropDwonModel> FoodCategoryDropDwonListPage = new List<FoodCategoryDropDwonModel>();
            foreach (DataRow dr in dtFoodCategory.Rows)
            {
                FoodCategoryDropDwonModel modelFoodCategoryDropDwon = new FoodCategoryDropDwonModel();
                modelFoodCategoryDropDwon.FoodCategoryID = Convert.ToInt32(dr["FoodCategoryID"]);
                modelFoodCategoryDropDwon.FoodCategoryName = dr["FoodCategoryName"].ToString();
                FoodCategoryDropDwonListPage.Add(modelFoodCategoryDropDwon);
            }
            ViewBag.FoodCategoryList = FoodCategoryDropDwonListPage;

            #endregion

            /*Product_DAL dalProduct = new Product_DAL();*/
            DataTable dtProduct = dalProduct.dbo_PR_Product_SelectAllByUserID();
            return View("ProductList", dtProduct);

        }
        #endregion dbo_PR_Product_SelectAll

        #endregion Index

        #region Add
        public IActionResult Add(int ProductID)
        {
            #region FoodCategory Drop Down

            Product_DAL dalProduct = new Product_DAL();
            DataTable dtFoodCategory = dalProduct.FoodCategoryDropDwon();

            List<FoodCategoryDropDwonModel> FoodCategoryDropDwonListPage = new List<FoodCategoryDropDwonModel>();
            foreach (DataRow dr in dtFoodCategory.Rows)
            {
                FoodCategoryDropDwonModel modelFoodCategoryDropDwon = new FoodCategoryDropDwonModel();
                modelFoodCategoryDropDwon.FoodCategoryID = Convert.ToInt32(dr["FoodCategoryID"]);
                modelFoodCategoryDropDwon.FoodCategoryName = dr["FoodCategoryName"].ToString();
                FoodCategoryDropDwonListPage.Add(modelFoodCategoryDropDwon);
            }
            ViewBag.FoodCategoryList = FoodCategoryDropDwonListPage;

            #endregion

            #region Select By PK

            if (ProductID != null)
            {
                DataTable dtProduct = dalProduct.dbo_PR_Product_SelectByPKUserID(ProductID);
                if (dtProduct.Rows.Count > 0)
                {
                    ProductModel modelProduct = new ProductModel();
                    foreach (DataRow dr in dtProduct.Rows)
                    {
                        modelProduct.ProductID = Convert.ToInt32(dr["ProductID"]);
                        modelProduct.UserID = Convert.ToInt32(dr["UserID"]);
                        modelProduct.ProductName = dr["ProductName"].ToString();
                        modelProduct.Description = dr["Description"].ToString();
                        modelProduct.Price = Convert.ToDecimal(dr["Price"]);
                        modelProduct.ProductImage = dr["ProductImage"].ToString();
                        modelProduct.FoodCategoryID = Convert.ToInt32(dr["FoodCategoryID"]);
                        modelProduct.ProductImage1 = dr["ProductImage1"].ToString();
                        modelProduct.ProductImage2 = dr["ProductImage2"].ToString();
                        modelProduct.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                        modelProduct.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);

                    }
                    return View("ProductAddEdit", modelProduct);
                }
            }
            #endregion

            return View("ProductAddEdit");
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult Save(ProductModel modelProduct)
        {
            #region PhotoPath
            if (modelProduct.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string fileNameWithPath = Path.Combine(path, modelProduct.File.FileName);
                modelProduct.ProductImage = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelProduct.File.FileName;
                modelProduct.ProductImage1 = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelProduct.File.FileName;
                modelProduct.ProductImage2 = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelProduct.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelProduct.File.CopyTo(stream);
                }

            }
            #endregion

            Product_DAL dalProduct = new Product_DAL();

            if (modelProduct.ProductID == null)
            {
                if (Convert.ToBoolean(dalProduct.PR_Product_InsertByUserID(modelProduct)))
                {
                    TempData["ProductInsertMessage"] = "Record inserted successfully";

                }
            }
            else
            {
                if (Convert.ToBoolean(dalProduct.dbo_PR_Product_UpdateByPKUserID(modelProduct)))
                {
                    TempData["ProductUpdateMessage"] = "Record Update Successfully";
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Add");
        }
        #endregion

        #region Delete
        public IActionResult Delete(int ProductID)
        {

            Product_DAL dalProduct = new Product_DAL();

            if (Convert.ToBoolean(dalProduct.dbo_PR_Product_DeleteByPKUserID(ProductID)))
            {
                return RedirectToAction("Index");
            }
            return View("Index");

        }
        #endregion Delete

        #region Product Filter
        public IActionResult PR_Product_SelectByFoodCategoryIDProductName(int FoodCategoryID, string ProductName)
        {
            Product_DAL dalProduct = new Product_DAL();
            DataTable dtProductFilter = dalProduct.PR_Product_SelectByFoodCategoryIDProductName(FoodCategoryID, ProductName);

            DataTable dtFoodCategoryDropDwon = dalProduct.FoodCategoryDropDwon();
            List<FoodCategoryDropDwonModel> FoodCategoryDropDownList = new List<FoodCategoryDropDwonModel>();
            foreach (DataRow dr in dtFoodCategoryDropDwon.Rows)
            {
                FoodCategoryDropDwonModel modelFoodCategoryDropDown = new FoodCategoryDropDwonModel();
                modelFoodCategoryDropDown.FoodCategoryID = (int)dr["FoodCategoryID"];
                modelFoodCategoryDropDown.FoodCategoryName = (string)dr["FoodCategoryName"];
                FoodCategoryDropDownList.Add(modelFoodCategoryDropDown);
            }
            ViewBag.CountryList = FoodCategoryDropDownList;
            
            return View("ProductList", dtProductFilter);

        }
        #endregion
    }
}
