using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;

namespace BookStoreAPI.Data
{
    [Table("books")]
    public partial class Book
    {
        [Column("bookid")]
        public int Bookid { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("description")]
        public string? Description { get; set; }
        [Column("authorid")]
        public int? Authorid { get; set; }
        [Column("price", TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }
        [Column("creationname")]
        public string CreationName { get; set; }
        [Column("revisionname")]
        public string? RevisionName { get; set; }
        [Column("creationdate")]
        public DateTime CreationDate { get; set; }
        [Column("revisiondate")]
        public DateTime? RevisionDate { get; set; }
        
        public virtual Author Author { get; set; }
    }
}