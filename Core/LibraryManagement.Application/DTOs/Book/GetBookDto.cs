namespace LibraryManagement.Application.DTOs.Book;

public record GetBookDto(
    int Id,
    string Title,
    string Author,
    string Genre,
    int Year,
    decimal Price
    );

