namespace Library.Domain.Validators;

public static class BookValidator
{
    public static string Title(string title)
    {
        return string.IsNullOrWhiteSpace(title)
            ? throw new ArgumentNullException(nameof(title), "Title is required")
            : title;
    }

    public static string Author(string author)
    {
        return string.IsNullOrWhiteSpace(author)
            ? throw new ArgumentNullException(nameof(author), "Author is required")
            : BookValidator.Capitalize(author);
    }

    public static string Genre(string genre)
    {
        return string.IsNullOrWhiteSpace(genre)
            ? throw new ArgumentNullException(nameof(genre), "Genre is required")
            : genre;
    }

    public static int PublicationYear(int publicationYear)
    {
        return publicationYear is <= 9999 and >= 1000
            ? publicationYear
            : throw new ArgumentOutOfRangeException(nameof(publicationYear),
                "Publication year must be between 1000 and 9999");
    }

    public static int Pages(int pages)
    {
        return pages > 0
            ? pages
            : throw new ArgumentOutOfRangeException(nameof(pages), "Pages must be greater than 0");
    }

    private static string Capitalize(string value)
    {
        var arr = value.Split(' ');
        var capArr = arr.Select(x => char.ToUpper(x[0]) + x.Substring(1));
        return string.Join(' ', capArr);
    }
}