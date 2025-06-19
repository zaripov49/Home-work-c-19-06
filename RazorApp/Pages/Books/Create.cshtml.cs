using Domain.DTOs.BookDTO;
using Infrastucture.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Books;

public class Create(IBookService bookService) : PageModel
{
    [BindProperty]
    public CreateBookDTO? CreateBookDTO { get; set; }

    public async Task<IActionResult> onPostAsync()
    {
        var response = await bookService.CreateBookAsync(CreateBookDTO);
        if (!response.IsSuccess)
        {
            return Page();
        }

        return RedirectToPage("index");
    }
}
