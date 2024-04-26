using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockLife.Classes
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [MaxLength(100)]
        public string Status { get; set; } = "pending";

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        // Навигационное свойство
        public User User { get; set; }
    }
}
