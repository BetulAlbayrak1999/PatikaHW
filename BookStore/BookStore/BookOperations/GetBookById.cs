using AutoMapper;
using BookStore.Common;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BookOperations
{
    public class GetBookById
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public GetBookById(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public BooksViewModelDetail Handle(int Id)
        {
            var book = _context.Books.Where(x =>x.Id == Id).SingleOrDefault();

            if (book is null)
                throw new InvalidOperationException("there is no book with this title");

            BooksViewModelDetail vm = _mapper.Map<BooksViewModelDetail>(book);
            /*
            BooksViewModel vm = new BooksViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/mm/yyyy");
            vm.GenreType = ((GenreEnum)book.GenreId).ToString();
            */
            return vm;
        }
        public class BooksViewModelDetail
        {
            public string Title { get; set; }

            public string GenreType { get; set; }

            public int PageCount { get; set; }

            public string PublishDate { get; set; }

        }
    }
}
