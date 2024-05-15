using System.ComponentModel.DataAnnotations;

namespace LapTrinhWebAPIBuoi1.Models.DTO
{
    public class LoginRequestDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
