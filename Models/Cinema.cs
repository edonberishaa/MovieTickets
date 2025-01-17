using MovieTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Cinema logo is required")]
        public string? Logo { get; set; }
        [Required(ErrorMessage = "Cinema Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Cinema Description is required")]
        public string? Description { get; set; }

        public List<Movie>? Movies { get; set; }
    }
}
