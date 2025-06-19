using Domain.DTOs.BookDTO;
using Infrastucture.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Books;

public class Index(IBookService bookService) : PageModel
{
    public List<GetBookDTO> Books { get; set; } = [];

    public async Task OnGetAsync()
    {
        var book = await bookService.GetBooksAsync();
        Books = book.Data!;
    }
}
