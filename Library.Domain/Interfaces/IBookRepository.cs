using Library.Domain.Entities;

namespace Library.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book?>> GetAllAsync(int? page, int? pageSize);
    Task<Book?> GetByIdAsync(int id);
    Task<Book> InsertAsync(Book book);
    Task<bool> DeleteAsync(int id);
    Task<Book> UpdateAsync(Book book);
}