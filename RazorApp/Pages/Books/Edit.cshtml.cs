using Domain.DTOs.BookDTO;
using Infrastucture.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Books;

public class Edit(IBookService bookService) : PageModel
{
    [BindProperty] public UpdateBookDTO? BookDTO { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var book = await bookService.GetBookByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        BookDTO = new UpdateBookDTO
        {
            Id = book.Data!.Id,
            Title = book.Data.Title,
            Author = book.Data.Author,
            Genre = book.Data.Genre,
            PublishedDate = book.Data.PublishedDate
        };

        return Page();
    }
}
