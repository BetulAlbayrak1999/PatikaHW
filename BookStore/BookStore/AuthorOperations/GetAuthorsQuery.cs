using AutoMapper;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.AuthorOperations
{
    public class GetAuthorsQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetAuthorsQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<AuthorsViewModel> Handle()
        {
            var authorList = _context.Authors.OrderBy(x => x.Id).ToList<Author>();
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(authorList);
            return vm;
        }

    }
    public class AuthorsViewModel
    {
        string Name { get; set; }
        string Surname { get; set; }
        string BirthDate { get; set; }
    }
}
