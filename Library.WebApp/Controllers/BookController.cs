using Library.Application.Interfaces;
using Library.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApp.Controllers;

[Authorize]
public class BookController : Controller
{
    public readonly ILogger<BookController> _logger;
    public readonly GetAllBooksUseCase _getAllBooksUseCase;
    public readonly GetBookByIdUseCase _getBookByIdUseCase;
    public readonly CreateBookUseCase _createBookUseCase;
    public readonly UpdateBookUseCase _updateBookUseCase;
    public readonly DeleteBookUseCase _deleteBookUseCase;

    public BookController(ILogger<BookController> logger,
        GetAllBooksUseCase getAllBooksUseCase,
        GetBookByIdUseCase getBookByIdUseCase,
        CreateBookUseCase createBookUseCase,
        UpdateBookUseCase updateBookUseCase,
        DeleteBookUseCase deleteBookUseCase)
    {
        _logger = logger;
        _getAllBooksUseCase = getAllBooksUseCase;
        _getBookByIdUseCase = getBookByIdUseCase;
        _createBookUseCase = createBookUseCase;
        _updateBookUseCase = updateBookUseCase;
        _deleteBookUseCase = deleteBookUseCase;
    }

    // GET: Book
    public async Task<IActionResult> Index([FromQuery] int? page = 1, [FromQuery] int? pageSize = 10)
    {
        var books = await _getAllBooksUseCase.ExecuteAsync(page, pageSize);

        return View(books);
    }

    // GET: Book/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var book = await _getBookByIdUseCase.ExecuteAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // GET: Book/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Book/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IFormCollection collection)
    {
        try
        {
            var book = new CreateBookRequest()
            {
                Title = collection["Title"].ToString(),
                Author = collection["Author"].ToString(),
                Genre = collection["Genre"].ToString(),
                PublicationYear = int.Parse(collection["PublicationYear"].ToString() ?? "0"),
                Pages = int.Parse(collection["Pages"].ToString() ?? "0"),
            };
            var result = await _createBookUseCase.ExecuteAsync(book);
            TempData["Message"] = "Book created successfully!";
            TempData["MessageType"] = "success";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["Message"] = ex.Message ?? "An error occurred while creating the book.";
            TempData["MessageType"] = "danger";
            return View();
        }
    }

    // GET: Book/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var book = await _getBookByIdUseCase.ExecuteAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // POST: Book/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, IFormCollection collection)
    {
        try
        {
            await _updateBookUseCase.ExecuteAsync(id, new UpdateBookRequest()
            {
                Title = collection["Title"].ToString(),
                Author = collection["Author"].ToString(),
                Genre = collection["Genre"].ToString(),
                PublicationYear = int.Parse(collection["PublicationYear"].ToString() ?? "0"),
                Pages = int.Parse(collection["Pages"].ToString() ?? "0"),
            });

            TempData["Message"] = "Book updated successfully!";
            TempData["MessageType"] = "success";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["Message"] = ex.Message ?? "An error occurred while updating the book.";
            TempData["MessageType"] = "danger";
            return View();
        }
    }

    // GET: Book/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var book = await _getBookByIdUseCase.ExecuteAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // POST: Book/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, IFormCollection collection)
    {
        try
        {
            await _deleteBookUseCase.ExecuteAsync(id);
            TempData["Message"] = "Book deleted successfully!";
            TempData["MessageType"] = "success";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["Message"] = ex.Message ?? "An error occurred while deleting the book.";
            TempData["MessageType"] = "danger";
            return View();
        }
    }
}