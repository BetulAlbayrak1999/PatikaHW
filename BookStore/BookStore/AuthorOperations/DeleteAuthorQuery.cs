using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.AuthorOperations
{
    public class DeleteAuthorQuery
    {
        private readonly Context _context;
        public int Id { get; set; }
        public DeleteAuthorQuery(Context context)
        {
            _context = context;
        }
        public void Handle() 
        {
            var author = _context.Authors.Find(Id);
            if (author is null)
                throw new InvalidOperationException("we don't have this author");
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}
