using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrder.Areas.PaymentMode.Models
{
    public class PaymentModeModel
    {
        public int? PaymentModeID { get; set; }

        [Required(ErrorMessage = "Please select PaymentType Name")]
        public string? PaymentTypeName { get; set; }
    }

    public class PaymentModeDropDwonModel
    {
        public int? PaymentModeID { get; set; }

        public string PaymentTypeName { get; set; }
    }

}
