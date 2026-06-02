namespace LibraryManagement.Application.DTOs.Book;

public record UpdateBookDto(
    string Title,
    string Author,
    string Genre,
    int Year,
    decimal Price
    );

