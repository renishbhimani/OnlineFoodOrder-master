using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrder.Areas.Order.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }

        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "Please select Customer")]
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please select Product")]
        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public Decimal TotalPrice { get; set; }
        public Decimal TotalAmount { get; set; }

        public int UserID { get; set; }

        [Required(ErrorMessage = "Please select PaymentMode")]
        public int PaymentModeID { get; set; }

        [Required(ErrorMessage = "Please select Reference No.")]
        public string? ReferenceNo { get; set; }

        public DateTime? ReferenceDate { get; set; }

        [Required(ErrorMessage = "Please select Bank Name")]
        public string? BankName { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
