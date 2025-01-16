using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTickets.Data;
using MovieTickets.Data.Services;

namespace MovieTickets.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerService _service;
        public ProducersController(IProducerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }
        //GET: producers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _service.GetByIdAsync(id);
            if(producerDetails == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(producerDetails);
            }
        }

    }
}
