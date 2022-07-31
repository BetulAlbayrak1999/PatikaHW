using AutoMapper;
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
        private readonly IMapper _mapper;
        public UpdateBookQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public UpdateBookModel Model;
        public int id;
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is null)
            {
                throw new InvalidOperationException("we don't have this book");
            }
            book.Id = id;
            book.Title = Model.Title;
            Model = _mapper.Map<UpdateBookModel>(book);

            _context.Books.Update(book);
            _context.SaveChanges();
        }

    }
    public class UpdateBookModel
    {
        public string Title { get; set; }

        public int GenreId { get; set; }

        public int PageCount { get; set; }

        public string PublishDate { get; set; }

    }
}
