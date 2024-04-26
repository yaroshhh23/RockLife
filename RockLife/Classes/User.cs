using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockLife.Repository;

namespace RockLife.Classes
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Login { get; set; }

        [Required, EmailAddress, MaxLength(255)]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string Password { get; set; }

        // Навигационные свойства
        public ICollection<Order> Orders { get; set; } // Заказы пользователя
        public ICollection<CartItem> CartItems { get; set; } // Элементы в корзине пользователя

        //public bool ValidateLogin(string username, string password)
        //{
        //    UserRepository userRepository = new UserRepository();
        //    return userRepository.Validate(username, password);
        //}
    }
}
