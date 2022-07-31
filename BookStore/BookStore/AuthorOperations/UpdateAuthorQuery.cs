using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.AuthorOperations
{
    public class UpdateAuthorQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public int Id;
        public UpdateAuthorModel Model { get; set; }
        public UpdateAuthorQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == Id);

            if (author is null)
                throw new InvalidOperationException("there is no author with this Id");

            author = _mapper.Map<Author>(Model);
            _context.Authors.Update(author);
            _context.SaveChanges();
        }

    }
    public class UpdateAuthorModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string BirthDate { get; set; }

    }
}
