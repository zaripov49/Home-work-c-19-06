using Domain.DTOs.BookDTO;
using Infrastucture.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers;

public class BookController(IBookService bookService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var book = await bookService.GetBooksAsync();
        return View(book);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBookDTO createBookDTO)
    {
        if (!ModelState.IsValid)
        {
            return View(createBookDTO);
        }

        await bookService.CreateBookAsync(createBookDTO);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var book = await bookService.GetBookByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateBookDTO updateBookDTO)
    {
        if (!ModelState.IsValid)
        {
            return View(updateBookDTO);
        }

        await bookService.UpdateBookAsync(updateBookDTO);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var book = await bookService.GetBookByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await bookService.DeleteBookAsync(id);
        return RedirectToAction("Index");
    }
}
