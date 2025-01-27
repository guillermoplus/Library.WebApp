using Library.Application.Interfaces;
using Library.Domain.Entities;
using Library.Domain.Interfaces;

namespace Library.Application.UseCases;

public class CreateBookUseCase
{
    private IBookRepository BookRepository { get; }

    public CreateBookUseCase(IBookRepository bookRepository)
    {
        BookRepository = bookRepository;
    }

    public async Task<BookResponse> ExecuteAsync(CreateBookRequest request)
    {
        var book = new Book(request.Title, request.Author, request.Genre, request.PublicationYear, request.Pages);

        var createdBook = await BookRepository.InsertAsync(book);

        return new BookResponse
        {
            Id = createdBook.Id,
            Title = createdBook.Title,
            Author = createdBook.Author,
            Genre = createdBook.Genre,
            PublicationYear = createdBook.PublicationYear,
            Pages = createdBook.Pages,
        };
    }
}