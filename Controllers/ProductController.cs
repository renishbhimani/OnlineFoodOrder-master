using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrder.Areas.FoodCategory.Models;
using OnlineFoodOrder.Areas.Product.Models;
using OnlineFoodOrder.BAL;
using OnlineFoodOrder.DAL;
using System.Data;

namespace OnlineFoodOrder.Controllers
{
    [CheckAccess_Client]
    public class ProductController : Controller
    {
        public IActionResult Index(int FoodCategoryID)
        {
            Product_DAL dalProduct = new Product_DAL();
            if (FoodCategoryID > 0)
            {
                DataTable dtProduct = dalProduct.dbo_PR_Product_ClientSide_SelectAllByFoodCategoryID(FoodCategoryID);
                return View("Product", dtProduct);

            }
            else
            {
                DataTable dtProduct = dalProduct.dbo_PR_Product_ClientSide_SelectAll();
                return View("Product", dtProduct);
            }

        }

        public IActionResult ProductDetail(int ProductID)
        {
            #region Select By PK

            Product_DAL dalProduct = new Product_DAL();
            DataTable dtProduct = dalProduct.dbo_PR_Product_ClientSide_SelectByPK(ProductID);
            return View("ProductDetail",dtProduct);

            #endregion

        }
    }
}
