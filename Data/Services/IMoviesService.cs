using MovieTickets.Data.Base;
using MovieTickets.Models;

namespace MovieTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
    }
}
