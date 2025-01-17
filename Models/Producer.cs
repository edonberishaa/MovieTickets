using MovieTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MovieTickets.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Fname must be between 3 and 50chars ")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }
        //Relationships
        public List<Movie> Movies  { get; set; }
    }
}
