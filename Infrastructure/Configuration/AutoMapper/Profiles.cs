using Application.Components.Books.Create;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Book, CreateNewBookCommand>().ReverseMap();
        }
    }
}
