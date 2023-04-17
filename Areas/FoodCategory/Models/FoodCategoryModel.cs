using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrder.Areas.FoodCategory.Models
{
    public class FoodCategoryModel
    {
        public int? FoodCategoryID { get; set; }

        [Required(ErrorMessage = "Please enter FoodCategoryName name")]
        [StringLength(10, MinimumLength = 3)]
        public string? FoodCategoryName { get;set; }

        public int UserID { get; set; }

        [Required(ErrorMessage = "Please enter Description")]
        public string? Description { get;set; }

        public IFormFile File { get; set; }
        public string? FoodCategoryImage { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }

    public class FoodCategoryDropDwonModel
    {
        public int FoodCategoryID { get; set; }

        public string FoodCategoryName { get; set; }
    }

}
