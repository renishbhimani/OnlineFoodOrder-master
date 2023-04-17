using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrder.Areas.Customer.Models
{
    public class CustomerModel
    {
        public int? CustomerID { get; set; }

        [Required(ErrorMessage = "Please enter Customer name")]
        [StringLength(10, MinimumLength = 3)]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter Mobile No")]
        public string? MobileNo { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter Password ")]
        [StringLength(10, MinimumLength = 5)]
        public string? Password { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }

    public class CustomerDropDwonModel
    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }
    }

}
