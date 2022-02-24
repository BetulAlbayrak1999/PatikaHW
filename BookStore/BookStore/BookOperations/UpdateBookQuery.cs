using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations
{
    public class UpdateBookQuery
    {
        private readonly Context _context;
        public UpdateBookQuery(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateBookModel Model)
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is null)
            {
                throw new InvalidOperationException("we don't have this book");
            }
            book = new Book();
            book.Title = Model.Title;
            book.PageCount = Model.PageCount;
            book.PublishDate = Model.PublishDate;
            book.GenreId = Model.GenreId;

            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public class UpdateBookModel
        {
            public string Title { get; set; }

            public int GenreId { get; set; }

            public int PageCount { get; set; }

            public DateTime PublishDate { get; set; }

        }
    }
}
