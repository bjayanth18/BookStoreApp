using System;
using System.Collections.Generic;

#nullable disable

namespace BookStoreAPI
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Id { get; set; }
        public string Bio { get; set; }
        public DateTime Creationdate { get; set; }
        public string Creationname { get; set; }
        public DateTime? Revisiondate { get; set; }
        public string Revisionname { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
