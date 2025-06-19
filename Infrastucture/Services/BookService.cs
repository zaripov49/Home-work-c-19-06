using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.BookDTO;
using Domain.Entities;
using Infrastucture.Data;
using Infrastucture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Services;

public class BookService(DataContext context, IMapper mapper) : IBookService
{
    public async Task<Response<List<GetBookDTO>>> GetBooksAsync()
    {
        var book = await context.Books
            .Select(b => new GetBookDTO
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Genre = b.Genre,
                PublishedDate = b.PublishedDate
            }).ToListAsync();

        return new Response<List<GetBookDTO>>(book);
    }

    public async Task<Response<string>> CreateBookAsync(CreateBookDTO createBookDTO)
    {
        var book = mapper.Map<Book>(createBookDTO);

        await context.Books.AddAsync(book);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Created book successfuly");
    }

    public async Task<Response<string>> DeleteBookAsync(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            return new Response<string>("Book not found", HttpStatusCode.NotFound);
        }

        context.Books.Remove(book);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Delete book successfuly");
    }

    public async Task<Response<string>> UpdateBookAsync(UpdateBookDTO updateBookDTO)
    {
        var book = await context.Books.FindAsync(updateBookDTO.Id);
        if (book == null)
        {
            return new Response<string>("Book not found", HttpStatusCode.NotFound);
        }

        mapper.Map(updateBookDTO, book);
        var result = await context.SaveChangesAsync();

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>(null, "Update book successfuly");
    }

    public async Task<Response<GetBookDTO>>? GetBookByIdAsync(int id)
    {
        var book = await context.Books.FindAsync(id);

        if (book == null)
        {
            return new Response<GetBookDTO>("Book not found", HttpStatusCode.NotFound);
        }

        var result = mapper.Map<GetBookDTO>(book);

        if (result == null)
        {
            return new Response<GetBookDTO>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<GetBookDTO>(result);
    }
}
