using BookAPI.Interfaces;
using BookAPI.Models;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks() => await _bookRepository.Get();

        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Book), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Book>> GetBookById(Guid id, Book book) 
        {
            await _bookRepository.GetBookById(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Book>> UpdateBook (Guid id,Book book)
        {
            if (id != book.Id) return BadRequest();
            await _bookRepository.Update(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> DeleteBook (Guid id, Book book)
        {
            if (id != book.Id) return NotFound();
            await _bookRepository.Delete(id);
            return NoContent();
        }
    }
}

