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
        public CreateGenreModel genreModel { get; set; } 
        public CreateGenreQuery(Context context)
        {
            _context = context;
        }


        public void Handle()
        {
            var genre = _context.Genres.Find(genreModel.Name);
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
