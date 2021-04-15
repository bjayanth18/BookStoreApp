using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.DTO;
using BookStoreAPI.RequestDTO;

namespace BookStoreAPI.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<AuthorDTO, AuthorRequestDto>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}