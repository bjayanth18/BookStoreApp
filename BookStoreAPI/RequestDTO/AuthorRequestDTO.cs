using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.RequestDTO
{
    public class AuthorRequestDto
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string? LastName { get; set; }

        public string Bio { get; set; } = null!;
    }
}