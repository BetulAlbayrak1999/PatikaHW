using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations
{
    public class CreateBookQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public CreateBookQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle(CreateBookModel Model)
        {
            var book = _context.Books.SingleOrDefault(x=> x.Title == Model.Title);
            if (book is not null) {
                throw new InvalidOperationException("we have this book");
            }

            book = _mapper.Map<Book>(Model);
            /*
             * book = new Book();
             * book.Title = Model.Title;
             * book.PageCount = Model.PageCount;
             * book.PublishDate = Model.PublishDate;
             * book.GenreId = Model.GenreId;*/

            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }

            public int GenreId { get; set; }

            public int PageCount { get; set; }

            public DateTime PublishDate { get; set; }

        }
    }
}
