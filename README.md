# Library Management System

Este proyecto es un sistema de gestión de bibliotecas desarrollado en C# y JavaScript. Proporciona funcionalidades para gestionar libros, incluyendo la creación, actualización, eliminación y consulta de libros.

## Tecnologías Utilizadas

- **Lenguajes**: C#, JavaScript
- **Frameworks**: .NET
- **IDE**: JetBrains Rider

## Estructura del Proyecto

El proyecto está organizado en los siguientes directorios:

- `Library.Domain`: Contiene las entidades, interfaces y validadores del dominio.
  - `Entities`: Define las entidades del dominio, como `Book`.
  - `Interfaces`: Define las interfaces de los repositorios, como `IBookRepository`.
  - `Validators`: Contiene los validadores para las entidades del dominio, como `BookValidator`.

## Entidades Principales

### Book

Representa un libro en el sistema.

```csharp
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
```

## Interfaces Principales

### IBookRepository

Define las operaciones CRUD para la entidad `Book`.

```csharp
public interface IBookRepository
{
    Task<IEnumerable<Book?>> GetAllAsync(int? page, int? pageSize);
    Task<Book?> GetByIdAsync(int id);
    Task<Book> InsertAsync(Book book);
    Task<bool> DeleteAsync(int id);
    Task<Book> UpdateAsync(Book book);
}
```

## Validadores

### BookValidator

Proporciona métodos de validación para las propiedades de `Book`.

```csharp
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
```

## Cómo Contribuir

1. Clona el repositorio.
2. Crea una nueva rama para tu funcionalidad (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commit (`git commit -m 'Añadir nueva funcionalidad'`).
4. Sube tus cambios (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT.