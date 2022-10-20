using BookAPI.Data;
using BookAPI.Interfaces;
using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;

        }

        public async Task Delete(Guid id)
        {
            var BookToDelete = await _context.Books.FindAsync(id);
            if (BookToDelete != null)
            {
                _context.Books.Remove(BookToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
