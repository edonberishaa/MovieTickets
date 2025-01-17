using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Services;
using MovieTickets.Models;

namespace MovieTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllASync(n => n.Cinema);
            return View(allMovies);
        }
        //GET: Movies/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        //GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our store!";
            ViewBag.Description = "Best store in universe!";
            return View();
        }
    }
}
