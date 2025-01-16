using MovieTickets.Data.Base;
using MovieTickets.Models;

namespace MovieTickets.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>,IProducerService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
            
        }
    }
}
