using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.AuthorOperations
{
    public class CreateAuthorQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model { get; set; }
        public CreateAuthorQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name);
            if (author is not null)
            {
                throw new InvalidOperationException("we have this book");
            }
            author = new Author();
            author = _mapper.Map<Author>(Model);
            _context.Add(author);
            _context.SaveChanges();
        }
    }
    public class CreateAuthorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
    }
}
