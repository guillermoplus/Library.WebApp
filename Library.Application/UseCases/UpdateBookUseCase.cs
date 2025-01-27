using Library.Application.Interfaces;
using Library.Domain.Interfaces;

namespace Library.Application.UseCases;

public class UpdateBookUseCase
{
    private IBookRepository bookRepository { get; set; }

    public UpdateBookUseCase(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public async Task<BookResponse> ExecuteAsync(int id, UpdateBookRequest request)
    {
        var book = await bookRepository.GetByIdAsync(id);

        if (book == null)
        {
            throw new Exception("Book not found");
        }

        book.Update(request.Title, request.Author, request.Genre, request.PublicationYear, request.Pages);

        var updatedBook = await bookRepository.UpdateAsync(book);

        return BookResponse.FromBook(updatedBook);
    }
}