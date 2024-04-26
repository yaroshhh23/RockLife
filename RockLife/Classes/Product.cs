using RockLife.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMysicStore.Classes
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Type { get; set; }

        [MaxLength(100)]
        public string Fabricator { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Color { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        // Навигационное свойство
        public ICollection<CartItem> CartItems { get; set; } // Связь с элементами, где продукт добавлен в корзину
    }
}
