using System.ComponentModel.DataAnnotations;

namespace iTechArt.SchoolSchedule.Models
{
    public class UserRegistrationModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}