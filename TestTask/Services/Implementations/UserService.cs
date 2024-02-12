using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<User> GetUser()
        {
            return await _context.Users.OrderByDescending(x => x.Orders.Count).FirstAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.Where(s => s.Status != 0).ToListAsync(); 
        }
    }
}
