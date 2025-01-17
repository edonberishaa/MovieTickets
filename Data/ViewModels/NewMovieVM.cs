using MovieTickets.Data.Base;
using MovieTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieTickets.Models;

namespace MovieTickets.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [Display(Name = "Movie Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Movie Description is required")]
        [Display(Name = "Movie Description")]

        public string? Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Movie Price")]

        public double Price { get; set; }
        [Required(ErrorMessage = "ImageURL is required")]
        [Display(Name = "Movie Image")]

        public string? ImageURL { get; set; }
        [Required(ErrorMessage = "Start Date is required")]
        [Display(Name = "Start Date")]

        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is required")]
        [Display(Name = "End Date")]

        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Movie category required")]
        [Display(Name = "Select a category")]
        public MovieCategory MovieCategory { get; set; }

        [Required(ErrorMessage = "Actor is required")]
        [Display(Name = "Select actor/s")]
        public List<int> ActorIds { get; set; }
        [Required(ErrorMessage = "Cinema is required")]
        [Display(Name = "Select a cinema")]

        public int CinemaId { get; set; }
        [Required(ErrorMessage = "Producer is required")]
        [Display(Name = "Select a producer")]
        public int ProducerId { get; set; }
    }
}