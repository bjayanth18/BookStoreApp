using System;

namespace BookStoreAPI.DTO
{
    public class BookDTO
    {
        public int Bookid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Authorid { get; set; }
        public Decimal Price { get; set; }
        public string CreationName { get; set; }
        public string RevisionName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RevisionDate { get; set; }
        public virtual AuthorDTO Author { get; set; }
    }
}