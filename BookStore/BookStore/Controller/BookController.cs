using BookStore.BookOperations;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BookStore.BookOperations.CreateBookQuery;
using static BookStore.BookOperations.GetBookById;
using static BookStore.BookOperations.UpdateBookQuery;

namespace BookStore.Controller
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

        [HttpGet]
        public IActionResult GetBook()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);

        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateItem([FromBody] UpdateBookModel book)
        {
            UpdateBookQuery query = new UpdateBookQuery(_context);

            try
            {
                query.Handle(book);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookModel book)
        {
            CreateBookQuery query = new CreateBookQuery(_context);
            try 
            {
                query.Handle(book);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
           
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int Id)
        {
            
            BooksViewModel result;
            try
            {
                GetBookById query = new GetBookById(_context);
                result = query.Handle(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        private bool ItemExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

    }
}