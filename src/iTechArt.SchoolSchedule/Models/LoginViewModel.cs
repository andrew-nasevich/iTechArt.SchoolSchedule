using System.ComponentModel.DataAnnotations;

namespace iTechArt.SchoolSchedule.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}