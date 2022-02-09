using BookOperationsPatika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOperationsPatika.BookOperations
{
    public class GetBookByIdQuery
    {
        private readonly Context _context;
        public GetBookByIdQuery(Context context)
        {
            _context = context;
        }     
        

        public BooksViewModel Handle(int id)
        {
            var book = _context.Books.Find(id);
            BooksViewModel vm = new BooksViewModel();
            vm.Title = book.Title;
            vm.GenreType = book.GenreType;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate;
           
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
