using Library.Domain.Validators;

namespace Library.Domain.Entities;

public class Book : EntityBase
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }
    public int Pages { get; set; }

    public Book(string title, string author, string genre, int publicationYear, int pages)
    {
        Title = BookValidator.Title(title);
        Author = BookValidator.Author(author);
        Genre = BookValidator.Genre(genre);
        PublicationYear = BookValidator.PublicationYear(publicationYear);
        Pages = BookValidator.Pages(pages);
    }

    /// <summary>
    /// Update the book properties
    /// </summary>
    /// <param name="title">Book's title</param>
    /// <param name="author">Book's author</param>
    /// <param name="genre">Book's genre</param>
    /// <param name="publicationYear">Book's publication year</param>
    /// <param name="pages">Total book's pages</param>
    /// <returns>Book instance</returns>
    public Book Update(string title, string author, string genre, int publicationYear, int pages)
    {
        Title = BookValidator.Title(title);
        Author = BookValidator.Author(author);
        Genre = BookValidator.Genre(genre);
        PublicationYear = BookValidator.PublicationYear(publicationYear);
        Pages = BookValidator.Pages(pages);

        return this;
    }
}