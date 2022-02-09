using BookOperationsPatika.BookOperations;
using BookOperationsPatika.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOperationsPatika.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly Context _context;
        public BookController(Context context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            GetBookByIdQuery query = new GetBookByIdQuery(_context);
            var result = query.Handle(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, Book updatedBook)
        {
            if (id != updatedBook.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Books.Update(updatedBook);

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updatedBook);
        }

        private bool ItemExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

    }
}
