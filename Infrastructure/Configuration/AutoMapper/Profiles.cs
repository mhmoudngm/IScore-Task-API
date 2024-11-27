using Application.Components.Author.List;
using Application.Components.Books.Create;
using Application.Components.Books.Edit;
using Application.Components.Books.List;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Configuration.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Book, CreateNewBookCommand>().ReverseMap();
            CreateMap<Book, EditBookCommand>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<BookDto, Book>().ReverseMap()
                .ForMember(i => i.AuthorId, s => s.MapFrom(i => i.AuthorId))
                .ForMember(i => i.AuthorName, s => s.MapFrom(i => i.Author.Name))
                .ForMember(i=>i.PublishedDate,s=>s.MapFrom(i=>i.PublishedDate.Date.ToString("MM-dd-yyyy")));
        }
    }
}
