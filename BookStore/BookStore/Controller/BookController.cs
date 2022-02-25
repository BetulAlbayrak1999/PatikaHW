using AutoMapper;
using BookStore.BookOperations;
using BookStore.Models;
using BookStore.Validator;
using FluentValidation;
using FluentValidation.Results;
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
        private readonly IMapper _mapper;
        public BookController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBook()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateItem([FromBody] UpdateBookModel book)
        {
            UpdateBookQuery query = new UpdateBookQuery(_context);
            UpdateBookValidator validator = new UpdateBookValidator();
            ValidationResult result = new ValidationResult();
            try
            {
                if (result.IsValid) {
                    query.Handle(book);
                    return Ok();
                }
                else {
                    return BadRequest();
                }
                    
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookModel book)
        {
            CreateBookQuery query = new CreateBookQuery(_context, _mapper);
            
            try 
            {
                CreateBookValidator validator = new CreateBookValidator();
                ValidationResult result = new ValidationResult();
                    
                validator.ValidateAndThrow(book);
                query.Handle(book);


            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
           
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int Id)
        {
            GetByIdBookValidator validator = new GetByIdBookValidator();
            ValidationResult re = new ValidationResult();

            BooksViewModelDetail result;
            
            GetBookById query = new GetBookById(_context, _mapper);
            if (re.IsValid)
            {
                    result = query.Handle(Id);
                    return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int Id)
        {
            Book book = _context.Books.Find(Id);
            try
            {
                DeleteBookValidator validator = new DeleteBookValidator();
                ValidationResult result = new ValidationResult();
                DeleteBookQuery query = new DeleteBookQuery(_context);

                validator.ValidateAndThrow(book);
                query.Handle(Id);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        private bool ItemExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

    }
}