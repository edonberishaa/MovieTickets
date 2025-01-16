using Microsoft.EntityFrameworkCore;
using MovieTickets.Data.Base;
using MovieTickets.Models;

namespace MovieTickets.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorService
    {
        public ActorsService(AppDbContext context) : base(context) { }
    }   
}
