using MovieTickets.Data.Base;
using MovieTickets.Models;

namespace MovieTickets.Data.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>,ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context) { }
    }
}
