#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreAPI.Data
{
    [Table("authors")]
    public class Author
    {
        [Column("firstname")]
        public string FirstName { get; set; }
        [Column("lastname")]
        public string? LastName { get; set; }
        [Column("bio")]
        public string? Bio { get; set; }
        [Column("id")]
        public int Id { get; set; }
        [Column("creationname")]
        public string CreationName { get; set; }
        [Column("revisionname")]
        public string? RevisionName { get; set; }
        [Column("creationdate")]
        public DateTime CreationDate { get; set; }
        [Column("revisiondate")]
        public DateTime? RevisionDate { get; set; }
        
        public virtual IList<Book> Books { get; set; }
    }
}