using AutoMapper;
using BookStore.Common;
using BookStore.GenreOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.CreateBookQuery;
using static BookStore.BookOperations.DeleteBookQuery;
using static BookStore.BookOperations.GetBookByIdQuery;
using static BookStore.BookOperations.GetBooksQuery;
using static BookStore.BookOperations.UpdateBookQuery;

namespace BookStore.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BooksViewModelDetail>().ForMember(dest => dest.GenreType, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.GenreType, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, UpdateBookModel>();
            CreateMap<UpdateBookModel, Book> ();
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, CreateGenreModel>();
            CreateMap<Genre, GenresViewDetailsModel>();
        }
        
    }
}
