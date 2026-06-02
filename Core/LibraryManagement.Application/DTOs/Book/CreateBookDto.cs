namespace LibraryManagement.Application.DTOs.Book;
public record CreateBookDto(
    string Title,
    string Author,
    string Genre,
    int Year,
    decimal Price
    );

