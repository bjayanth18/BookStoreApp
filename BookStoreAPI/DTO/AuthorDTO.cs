using System;
using System.Collections.Generic;

namespace BookStoreAPI.DTO
{
    public class AuthorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public int Id { get; set; }
        public string CreationName { get; set; }
        public string RevisionName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime RevisionDate { get; set; }
        public virtual IList<BookDTO> Books { get; set; }
    }
}