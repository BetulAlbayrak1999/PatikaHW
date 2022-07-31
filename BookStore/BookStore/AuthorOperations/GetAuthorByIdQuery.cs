using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.AuthorOperations
{
    public class GetAuthorByIdQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public int Id;
        public GetAuthorByIdQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorsViewModelDetail Handle() 
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == Id); ;
            if (author is null)
                throw new InvalidOperationException("we don't have this author");
            return _mapper.Map<AuthorsViewModelDetail>(author);
        }

    }
    public class AuthorsViewModelDetail
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string BirthDate { get; set; }

    }
}
