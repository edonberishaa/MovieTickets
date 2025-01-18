using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public int Amount { get; set; }
        public string ShoppingCart { get; set; }
    }

}
