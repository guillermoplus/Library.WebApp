using Library.Domain.Entities;
using Library.Domain.Interfaces;
using Library.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book?>> GetAllAsync(int? page, int? pageSize)
    {
        if (!page.HasValue && !pageSize.HasValue)
        {
            return await _context.Books.ToListAsync();
        }

        return await _context.Books
            .Skip(((page ?? 1) - 1) * pageSize ?? 10)
            .Take(pageSize ?? 10)
            .ToListAsync();
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> InsertAsync(Book book)
    {
        book.CreatedOn = DateTime.UtcNow;
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return true;
        }

        _context.Books.Remove(book);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Book> UpdateAsync(Book book)
    {
        book.UpdatedOn = DateTime.UtcNow;
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return book;
    }
}