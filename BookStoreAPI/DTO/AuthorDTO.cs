#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.DTO
{
    public class AuthorDTO
    {
        public AuthorDTO()
        {
            CreationName = Environment.UserName;
            CreationDate = DateTime.Now;
            RevisionDate = DateTime.Now;
            RevisionName = Environment.UserName;
        }
        
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }
        public string? Bio { get; set; }
        public int Id { get; set; }
        public string CreationName { get; set; }
        public string? RevisionName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? RevisionDate { get; set; }
        public virtual IList<BookDTO> Books { get; set; } = null!;
    }
}