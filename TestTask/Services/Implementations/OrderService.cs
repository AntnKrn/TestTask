using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order> GetOrder()
        {
            return await _context.Orders.OrderByDescending(p => p.Price * p.Quantity).FirstAsync();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await _context.Orders.Where(s => s.Quantity > 10).ToListAsync();
        }
    }
}
