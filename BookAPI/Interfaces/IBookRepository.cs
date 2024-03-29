﻿using BookAPI.Models;

namespace BookAPI.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> GetBookById(Guid id);
        Task<IEnumerable<Book>> Get();
        Task Delete(Guid id);

        Task<Book> Create(Book book);
        Task<Book> Update(Book book);
    }
}
