namespace Domain.DTOs.BookDTO;

public class CreateBookDTO
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
    public DateTime PublishedDate { get; set; }
}
