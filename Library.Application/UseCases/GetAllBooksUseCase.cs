using Library.Application.Interfaces;
using Library.Domain.Interfaces;

namespace Library.Application.UseCases;

public class GetAllBooksUseCase
{
    private IBookRepository _bookRepository;

    public GetAllBooksUseCase(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<BookResponse>> ExecuteAsync(int? page, int? pageSize)
    {
        var books = await _bookRepository.GetAllAsync(page, pageSize);
        return books.Select(BookResponse.FromBook);
    }
}