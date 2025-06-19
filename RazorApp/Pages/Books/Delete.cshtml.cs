using Infrastucture.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Books;

public class Delete(IBookService bookService) : PageModel
{
    [BindProperty] public int Id { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var book = await bookService.GetBookByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        Id = book.Data!.Id;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var book = await bookService.DeleteBookAsync(Id);
        if (!book.IsSuccess)
        {
            return Page();
        }
        return RedirectToPage("index");
    }
}
