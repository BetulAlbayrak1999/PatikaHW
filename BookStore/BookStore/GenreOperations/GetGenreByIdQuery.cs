using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.GenreOperations
{
    public class GetGenreByIdQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }
        public GetGenreByIdQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenresViewDetailsModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genre is null)
                throw new InvalidOperationException("this genre deosn't exist");
            return _mapper.Map<GenresViewDetailsModel>(genre);
        }
    }
    public class GenresViewDetailsModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}

