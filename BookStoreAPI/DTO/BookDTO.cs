#nullable enable
using System;

namespace BookStoreAPI.DTO
{
    public class BookDTO
    {
        public BookDTO()
        {
            CreationName = Environment.UserName;
            CreationDate = DateTime.Now;
            RevisionDate = DateTime.Now;
            RevisionName = Environment.UserName;
        }
        public int Bookid { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Authorid { get; set; }
        public decimal? Price { get; set; }
        public string CreationName { get; set; }
        public string? RevisionName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? RevisionDate { get; set; }
        public virtual AuthorDTO Author { get; set; }
    }
}