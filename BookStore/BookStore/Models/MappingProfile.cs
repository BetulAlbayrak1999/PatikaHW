using AutoMapper;
using BookStore.Common;
using BookStore.GenreOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.CreateBookQuery;
using static BookStore.BookOperations.DeleteBookQuery;
using static BookStore.BookOperations.GetBookById;
using static BookStore.BookOperations.GetBooksQuery;

namespace BookStore.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModelDetail>().ForMember(dest => dest.GenreType, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.GenreType, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenresViewDetailsModel>();
        }
        
    }
}
