using Domain.ApiResponse;
using Domain.DTOs.BookDTO;

namespace Infrastucture.Interfaces;

public interface IBookService
{
    Task<Response<List<GetBookDTO>>> GetBooksAsync();
    Task<Response<string>> CreateBookAsync(CreateBookDTO createBookDTO);
    Task<Response<string>> UpdateBookAsync(UpdateBookDTO updateBookDTO);
    Task<Response<string>> DeleteBookAsync(int id);
    Task<Response<GetBookDTO?>> GetBookByIdAsync(int id);
}
