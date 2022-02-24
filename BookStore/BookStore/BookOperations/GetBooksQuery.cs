using BookStore.Common;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations
{
    public class GetBooksQuery
    {
        private readonly Context _context;
        public GetBooksQuery(Context context)
        {
            _context = context;
        }


        public List<BooksViewModel> Handle()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
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
            }

            return vm;
        }

        public class BooksViewModel
        {
            public string Title { get; set; }

            public string GenreType { get; set; }

            public int PageCount { get; set; }

            public string PublishDate { get; set; }

        }

    }
}
