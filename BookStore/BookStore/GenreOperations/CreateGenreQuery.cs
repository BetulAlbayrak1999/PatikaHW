using AutoMapper;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.GenreOperations
{
    public class CreateGenreQuery
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public CreateGenreModel genreModel { get; set; } 
        public CreateGenreQuery(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name==genreModel.Name);
            if (genre is not null)
                throw new InvalidOperationException("we have this genre");
            genre = new Genre();
            genre.Name = genreModel.Name;
            _context.Add(genre);
            _context.SaveChanges();
        }

    }
    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}
