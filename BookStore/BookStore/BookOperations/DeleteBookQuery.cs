using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations
{
    public class DeleteBookQuery
    {
        private readonly Context _context;
        public DeleteBookQuery(Context context)
        {
            _context = context;
        }
        public void Handle(int Id)
        {
            var book = _context.Books.Where(x => x.Id == Id).SingleOrDefault();

            if (book is null)
                throw new InvalidOperationException("there is no book with this title");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

    }
}
