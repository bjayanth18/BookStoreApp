using System.ComponentModel.DataAnnotations;

namespace BookStoreAPI.RequestDTO
{
    public class BookRequestDTO
    {
        public int Bookid { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        public int? Authorid { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}