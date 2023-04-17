using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OnlineFoodOrder.Areas.User.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
