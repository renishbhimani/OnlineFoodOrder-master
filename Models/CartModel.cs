namespace OnlineFoodOrder.Models
{
    public class CartModel
    {
        public int CartID { get; set; }
        public int ProductID { get; set;}
        public string ProductName { get; set; }
        public IFormFile File { get; set; }
        public string ProductImage { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
