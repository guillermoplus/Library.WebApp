using Library.Application.Interfaces;
using Library.Domain.Interfaces;

namespace Library.Application.UseCases;

public class DeleteBookUseCase
{
    private IBookRepository BookRepository { get; init; }

    public DeleteBookUseCase(IBookRepository bookRepository)
    {
        this.BookRepository = bookRepository;
    }

    public async Task<bool> ExecuteAsync(int id)
    {
        return await BookRepository.DeleteAsync(id);
    }
}