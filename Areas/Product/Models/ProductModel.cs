using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrder.Areas.Product.Models
{
    public class ProductModel
    {
        public int? ProductID { get; set; }

        [Required(ErrorMessage = "Please select Product Name")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Please select Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Please select Price")]
        public decimal Price { get; set; }

        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Please select Product Image")]
        public string? ProductImage { get; set; }

        public int UserID { get; set; }

        [Required(ErrorMessage = "Please select FoodCategory Name")]
        public int FoodCategoryID { get; set; }

        [Required(ErrorMessage = "Please select Product Image1")]
        public string? ProductImage1 { get; set; }

        [Required(ErrorMessage = "Please select Product Image2")]
        public string? ProductImage2 { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }

    public class ProductDropDwonModel
    {
        public int? ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }

}
