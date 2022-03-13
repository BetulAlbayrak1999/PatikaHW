using AutoMapper;
using BookStore.Common;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations
{
    public class GetBooksQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetBooksQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.Include(x=> x.Genre).OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map <List<BooksViewModel>>(bookList);
            /*
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    GenreType = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy"),
                    PageCount = book.PageCount
                });    
            }*/

            return vm;
        }

        public class BooksViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }

            public string GenreType { get; set; }

            public int PageCount { get; set; }

            public string PublishDate { get; set; }

        }

    }
}
