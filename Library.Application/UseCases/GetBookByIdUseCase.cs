using Library.Application.Interfaces;
using Library.Domain.Interfaces;

namespace Library.Application.UseCases;

public class GetBookByIdUseCase
{
    private IBookRepository bookRepository { get; init; }

    public GetBookByIdUseCase(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<BookResponse?> ExecuteAsync(int id)
    {
        var book = await bookRepository.GetByIdAsync(id);

        return null ?? BookResponse.FromBook(book);
    }
}