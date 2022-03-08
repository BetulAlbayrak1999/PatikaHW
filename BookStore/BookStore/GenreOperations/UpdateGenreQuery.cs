using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.GenreOperations
{
    public class UpdateGenreQuery
    {
        private readonly Context _context;
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }
        public UpdateGenreQuery(Context context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.Find(GenreId);
            if (genre is null)
                throw new InvalidOperationException("we don't have this genre");
            if(_context.Genres.Any(x=>x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
            genre.Name = Model.Name.Trim() == default ? Model.Name : genre.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
