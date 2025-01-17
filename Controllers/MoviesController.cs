using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllASync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index",filteredResult);
            }
            return View("Index",allMovies);
        }
        //GET: Movies/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _service.GetNewMovieDropdownValues();

            ViewBag.CinemaId = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.ActorId = new SelectList(movieDropdownData.Actors, "Id", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownValues();

                ViewBag.CinemaId = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
                ViewBag.ProducerId = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.ActorId = new SelectList(movieDropdownData.Actors, "Id", "FullName");

                return View(movie);
            }
            else
            {
                await _service.AddNewMovieAsync(movie);
                return RedirectToAction("Index");
            }
        }
        //GET: Movies/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null)
            {
                return View("NotFound");
            }
            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()
            };

            var movieDropdownData = await _service.GetNewMovieDropdownValues();

            ViewBag.CinemaId = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
            ViewBag.ProducerId = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.ActorId = new SelectList(movieDropdownData.Actors, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewMovieVM movie)
        {
            if(id != movie.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownValues();

                ViewBag.CinemaId = new SelectList(movieDropdownData.Cinemas, "Id", "Name");
                ViewBag.ProducerId = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.ActorId = new SelectList(movieDropdownData.Actors, "Id", "FullName");

                return View(movie);
            }
            else
            {
                await _service.UpdateMovieAsync(movie);
                return RedirectToAction("Index");
            }
        }
    }
}
