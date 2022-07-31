using AutoMapper;
using BookStore.AuthorOperations;
using BookStore.BookOperations;
using BookStore.Common;
using BookStore.GenreOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.AuthorOperations.CreateAuthorQuery;
using static BookStore.AuthorOperations.GetAuthorByIdQuery;
using static BookStore.AuthorOperations.GetAuthorsQuery;
using static BookStore.AuthorOperations.UpdateAuthorQuery;
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
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, CreateGenreModel>();
            CreateMap<Genre, GenresViewDetailsModel>();
            CreateMap<Author, CreateAuthorModel>();
            CreateMap<Author, AuthorsViewModel>();
            CreateMap<Author, AuthorsViewModelDetail>();
            CreateMap<Author, UpdateAuthorModel>();
        }
        
    }
}
