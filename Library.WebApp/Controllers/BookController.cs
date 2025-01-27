using Microsoft.AspNetCore.Mvc;

namespace Library.WebApp.Controllers;

public class BookController : Controller
{
    public readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    // GET: Book
    public IActionResult Index()
    {
        return View();
    }

    // GET: Book/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: Book/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Book/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Book/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: Book/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: Book/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: Book/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}