using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreAPI
{
    public partial class Book
    {
        public string Title { get; set; }
        public int Bookid { get; set; }
        public string Description { get; set; }
        public int? Authorid { get; set; }
        public decimal? Price { get; set; }
        public string Creationname { get; set; }
        public string Revisionname { get; set; }
        public DateTime Creationdate { get; set; }
        public DateTime? Revisiondate { get; set; }

        public virtual Author Author { get; set; }
    }
}
