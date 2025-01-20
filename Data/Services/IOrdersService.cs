using MovieTickets.Data.Cart;
using MovieTickets.Models;

namespace MovieTickets.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
