using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdoUsingCREDOperation.Models
{
    [Table("Customers")]

    public class Customers
    {
        [Key]
        [ScaffoldColumn(false)]
        public int id { get; set; }
        [Required(ErrorMessage = "name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "contact is required")]
        public string contact { get; set; }
        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
