using Microsoft.EntityFrameworkCore;
using RockLife.Classes;
using RockLife.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockLife.Repository
{
    internal class UserRepository: IUserRepository
    {
        private readonly RlContext _context; 

        public UserRepository(RlContext context)
        {
            _context = context;
        }

        // Добавление нового пользователя
        public async Task AddUserAsync(User user)
        {
            // Проверка на валидность модели перед добавлением
            Validator.ValidateObject(user, new ValidationContext(user), true);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        // Получение пользователя по ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        // Обновление данных пользователя
        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // Удаление пользователя по ID
        public async Task DeleteUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        // Получение всех пользователей
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Поиск пользователей по логину
        public async Task<List<User>> FindUsersByLoginAsync(string login)
        {
            return await _context.Users
                .Where(u => u.Login.Contains(login))
                .ToListAsync();
        }
    }
}
